// Decompiled with JetBrains decompiler
// Type: Terraria.IO.Preferences
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Terraria.Localization;

namespace Terraria.IO
{
  public class Preferences
  {
    private Dictionary<string, object> _data = new Dictionary<string, object>();
    private readonly object _lock = new object();
    private readonly string _path;
    private readonly JsonSerializerSettings _serializerSettings;
    public readonly bool UseBson;
    public bool AutoSave;

    public event Action<Preferences> OnSave;

    public event Action<Preferences> OnLoad;

    public event Preferences.TextProcessAction OnProcessText;

    public Preferences(string path, bool parseAllTypes = false, bool useBson = false)
    {
      this._path = path;
      this.UseBson = useBson;
      if (parseAllTypes)
      {
        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        serializerSettings.set_TypeNameHandling((TypeNameHandling) 4);
        serializerSettings.set_MetadataPropertyHandling((MetadataPropertyHandling) 1);
        serializerSettings.set_Formatting((Formatting) 1);
        this._serializerSettings = serializerSettings;
      }
      else
      {
        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        serializerSettings.set_Formatting((Formatting) 1);
        this._serializerSettings = serializerSettings;
      }
    }

    public bool Load()
    {
      bool flag = false;
      object obj;
      try
      {
        Monitor.Enter(obj = this._lock, ref flag);
        if (!File.Exists(this._path))
          return false;
        try
        {
          if (!this.UseBson)
          {
            this._data = (Dictionary<string, object>) JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(this._path), this._serializerSettings);
          }
          else
          {
            using (FileStream fileStream = File.OpenRead(this._path))
            {
              using (BsonReader bsonReader = new BsonReader((Stream) fileStream))
                this._data = (Dictionary<string, object>) JsonSerializer.Create(this._serializerSettings).Deserialize<Dictionary<string, object>>((JsonReader) bsonReader);
            }
          }
          if (this._data == null)
            this._data = new Dictionary<string, object>();
          if (this.OnLoad != null)
            this.OnLoad(this);
          return true;
        }
        catch (Exception ex)
        {
          return false;
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(obj);
      }
    }

    public bool Save(bool createFile = true)
    {
      bool flag = false;
      object obj;
      try
      {
        Monitor.Enter(obj = this._lock, ref flag);
        try
        {
          if (this.OnSave != null)
            this.OnSave(this);
          if (!createFile && !File.Exists(this._path))
            return false;
          Directory.GetParent(this._path).Create();
          if (!createFile)
            File.SetAttributes(this._path, FileAttributes.Normal);
          if (!this.UseBson)
          {
            string text = JsonConvert.SerializeObject((object) this._data, this._serializerSettings);
            if (this.OnProcessText != null)
              this.OnProcessText(ref text);
            File.WriteAllText(this._path, text);
            File.SetAttributes(this._path, FileAttributes.Normal);
          }
          else
          {
            using (FileStream fileStream = File.Create(this._path))
            {
              using (BsonWriter bsonWriter = new BsonWriter((Stream) fileStream))
              {
                File.SetAttributes(this._path, FileAttributes.Normal);
                JsonSerializer.Create(this._serializerSettings).Serialize((JsonWriter) bsonWriter, (object) this._data);
              }
            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(Language.GetTextValue("Error.UnableToWritePreferences", (object) this._path));
          Console.WriteLine(ex.ToString());
          Monitor.Exit(this._lock);
          return false;
        }
        return true;
      }
      finally
      {
        if (flag)
          Monitor.Exit(obj);
      }
    }

    public void Clear()
    {
      this._data.Clear();
    }

    public void Put(string name, object value)
    {
      bool flag = false;
      object obj;
      try
      {
        Monitor.Enter(obj = this._lock, ref flag);
        this._data[name] = value;
        if (!this.AutoSave)
          return;
        this.Save(true);
      }
      finally
      {
        if (flag)
          Monitor.Exit(obj);
      }
    }

    public bool Contains(string name)
    {
      bool flag = false;
      object obj;
      try
      {
        Monitor.Enter(obj = this._lock, ref flag);
        return this._data.ContainsKey(name);
      }
      finally
      {
        if (flag)
          Monitor.Exit(obj);
      }
    }

    public T Get<T>(string name, T defaultValue)
    {
      bool flag = false;
      object obj1;
      try
      {
        Monitor.Enter(obj1 = this._lock, ref flag);
        try
        {
          object obj2;
          if (!this._data.TryGetValue(name, out obj2))
            return defaultValue;
          if (obj2 is T)
            return (T) obj2;
          if (obj2 is JObject)
            return JsonConvert.DeserializeObject<T>(((object) (JObject) obj2).ToString());
          return (T) Convert.ChangeType(obj2, typeof (T));
        }
        catch
        {
          return defaultValue;
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(obj1);
      }
    }

    public void Get<T>(string name, ref T currentValue)
    {
      currentValue = this.Get<T>(name, currentValue);
    }

    public List<string> GetAllKeys()
    {
      return this._data.Keys.ToList<string>();
    }

    public delegate void TextProcessAction(ref string text);
  }
}
