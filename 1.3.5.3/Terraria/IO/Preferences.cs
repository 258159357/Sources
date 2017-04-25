// Decompiled with JetBrains decompiler
// Type: Terraria.IO.Preferences
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

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
        int num1 = 4;
        serializerSettings.set_TypeNameHandling((TypeNameHandling) num1);
        int num2 = 1;
        serializerSettings.set_MetadataPropertyHandling((MetadataPropertyHandling) num2);
        int num3 = 1;
        serializerSettings.set_Formatting((Formatting) num3);
        this._serializerSettings = serializerSettings;
      }
      else
      {
        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        int num = 1;
        serializerSettings.set_Formatting((Formatting) num);
        this._serializerSettings = serializerSettings;
      }
    }

    public bool Load()
    {
      lock (this._lock)
      {
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
            using (FileStream resource_1 = File.OpenRead(this._path))
            {
              using (BsonReader resource_0 = new BsonReader((Stream) resource_1))
                this._data = (Dictionary<string, object>) JsonSerializer.Create(this._serializerSettings).Deserialize<Dictionary<string, object>>((JsonReader) resource_0);
            }
          }
          if (this._data == null)
            this._data = new Dictionary<string, object>();
          // ISSUE: reference to a compiler-generated field
          if (this.OnLoad != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.OnLoad(this);
          }
          return true;
        }
        catch (Exception exception_0)
        {
          return false;
        }
      }
    }

    public bool Save(bool createFile = true)
    {
      lock (this._lock)
      {
        try
        {
          // ISSUE: reference to a compiler-generated field
          if (this.OnSave != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.OnSave(this);
          }
          if (!createFile && !File.Exists(this._path))
            return false;
          Directory.GetParent(this._path).Create();
          if (!createFile)
            File.SetAttributes(this._path, FileAttributes.Normal);
          if (!this.UseBson)
          {
            string local_3 = JsonConvert.SerializeObject((object) this._data, this._serializerSettings);
            // ISSUE: reference to a compiler-generated field
            if (this.OnProcessText != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.OnProcessText(ref local_3);
            }
            File.WriteAllText(this._path, local_3);
            File.SetAttributes(this._path, FileAttributes.Normal);
          }
          else
          {
            using (FileStream resource_1 = File.Create(this._path))
            {
              using (BsonWriter resource_0 = new BsonWriter((Stream) resource_1))
              {
                File.SetAttributes(this._path, FileAttributes.Normal);
                JsonSerializer.Create(this._serializerSettings).Serialize((JsonWriter) resource_0, (object) this._data);
              }
            }
          }
        }
        catch (Exception exception_0)
        {
          Console.WriteLine(Language.GetTextValue("Error.UnableToWritePreferences", (object) this._path));
          Console.WriteLine(exception_0.ToString());
          Monitor.Exit(this._lock);
          return false;
        }
        return true;
      }
    }

    public void Clear()
    {
      this._data.Clear();
    }

    public void Put(string name, object value)
    {
      lock (this._lock)
      {
        this._data[name] = value;
        if (!this.AutoSave)
          return;
        this.Save(true);
      }
    }

    public bool Contains(string name)
    {
      lock (this._lock)
        return this._data.ContainsKey(name);
    }

    public T Get<T>(string name, T defaultValue)
    {
      lock (this._lock)
      {
        try
        {
          object local_2;
          if (!this._data.TryGetValue(name, out local_2))
            return defaultValue;
          if (local_2 is T)
            return (T) local_2;
          if (local_2 is JObject)
            return JsonConvert.DeserializeObject<T>(((object) (JObject) local_2).ToString());
          return (T) Convert.ChangeType(local_2, typeof (T));
        }
        catch
        {
          return defaultValue;
        }
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
