﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.AchievementManager
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
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.Achievements
{
  public class AchievementManager
  {
    private static object _ioLock = new object();
    private Dictionary<string, Achievement> _achievements = new Dictionary<string, Achievement>();
    private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();
    private Dictionary<string, int> _achievementIconIndexes = new Dictionary<string, int>();
    private string _savePath;
    private bool _isCloudSave;
    private byte[] _cryptoKey;

    public event Achievement.AchievementCompleted OnAchievementCompleted;

    public AchievementManager()
    {
      if (SocialAPI.Achievements != null)
      {
        this._savePath = SocialAPI.Achievements.GetSavePath();
        this._isCloudSave = true;
        this._cryptoKey = SocialAPI.Achievements.GetEncryptionKey();
      }
      else
      {
        this._savePath = Main.SavePath + (object) Path.DirectorySeparatorChar + "achievements.dat";
        this._isCloudSave = false;
        this._cryptoKey = Encoding.ASCII.GetBytes("RELOGIC-TERRARIA");
      }
    }

    public void Save()
    {
      this.Save(this._savePath, this._isCloudSave);
    }

    private void Save(string path, bool cloud)
    {
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = AchievementManager._ioLock, ref flag);
        if (SocialAPI.Achievements != null)
          SocialAPI.Achievements.StoreStats();
        try
        {
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, new RijndaelManaged().CreateEncryptor(this._cryptoKey, this._cryptoKey), CryptoStreamMode.Write))
            {
              using (BsonWriter bsonWriter = new BsonWriter((Stream) cryptoStream))
              {
                JsonSerializer.Create(this._serializerSettings).Serialize((JsonWriter) bsonWriter, (object) this._achievements);
                ((JsonWriter) bsonWriter).Flush();
                cryptoStream.FlushFinalBlock();
                FileUtilities.WriteAllBytes(path, memoryStream.ToArray(), cloud);
              }
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }

    public List<Achievement> CreateAchievementsList()
    {
      return this._achievements.Values.ToList<Achievement>();
    }

    public void Load()
    {
      this.Load(this._savePath, this._isCloudSave);
    }

    private void Load(string path, bool cloud)
    {
      bool flag1 = false;
      bool flag2 = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = AchievementManager._ioLock, ref flag2);
        if (!FileUtilities.Exists(path, cloud))
          return;
        byte[] buffer = FileUtilities.ReadAllBytes(path, cloud);
        Dictionary<string, AchievementManager.StoredAchievement> dictionary = (Dictionary<string, AchievementManager.StoredAchievement>) null;
        try
        {
          using (MemoryStream memoryStream = new MemoryStream(buffer))
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, new RijndaelManaged().CreateDecryptor(this._cryptoKey, this._cryptoKey), CryptoStreamMode.Read))
            {
              using (BsonReader bsonReader = new BsonReader((Stream) cryptoStream))
                dictionary = (Dictionary<string, AchievementManager.StoredAchievement>) JsonSerializer.Create(this._serializerSettings).Deserialize<Dictionary<string, AchievementManager.StoredAchievement>>((JsonReader) bsonReader);
            }
          }
        }
        catch (Exception ex)
        {
          FileUtilities.Delete(path, cloud);
          return;
        }
        if (dictionary == null)
          return;
        foreach (KeyValuePair<string, AchievementManager.StoredAchievement> keyValuePair in dictionary)
        {
          if (this._achievements.ContainsKey(keyValuePair.Key))
            this._achievements[keyValuePair.Key].Load(keyValuePair.Value.Conditions);
        }
        if (SocialAPI.Achievements != null)
        {
          foreach (KeyValuePair<string, Achievement> achievement in this._achievements)
          {
            if (achievement.Value.IsCompleted && !SocialAPI.Achievements.IsAchievementCompleted(achievement.Key))
            {
              flag1 = true;
              achievement.Value.ClearProgress();
            }
          }
        }
      }
      finally
      {
        if (flag2)
          Monitor.Exit(ioLock);
      }
      if (!flag1)
        return;
      this.Save();
    }

    private void AchievementCompleted(Achievement achievement)
    {
      this.Save();
      if (this.OnAchievementCompleted == null)
        return;
      this.OnAchievementCompleted(achievement);
    }

    public void Register(Achievement achievement)
    {
      this._achievements.Add(achievement.Name, achievement);
      achievement.OnCompleted += new Achievement.AchievementCompleted(this.AchievementCompleted);
    }

    public void RegisterIconIndex(string achievementName, int iconIndex)
    {
      this._achievementIconIndexes.Add(achievementName, iconIndex);
    }

    public void RegisterAchievementCategory(string achievementName, AchievementCategory category)
    {
      this._achievements[achievementName].SetCategory(category);
    }

    public Achievement GetAchievement(string achievementName)
    {
      Achievement achievement;
      if (this._achievements.TryGetValue(achievementName, out achievement))
        return achievement;
      return (Achievement) null;
    }

    public T GetCondition<T>(string achievementName, string conditionName) where T : AchievementCondition
    {
      return this.GetCondition(achievementName, conditionName) as T;
    }

    public AchievementCondition GetCondition(string achievementName, string conditionName)
    {
      Achievement achievement;
      if (this._achievements.TryGetValue(achievementName, out achievement))
        return achievement.GetCondition(conditionName);
      return (AchievementCondition) null;
    }

    public int GetIconIndex(string achievementName)
    {
      int num;
      if (this._achievementIconIndexes.TryGetValue(achievementName, out num))
        return num;
      return 0;
    }

    private class StoredAchievement
    {
      public Dictionary<string, JObject> Conditions;
    }
  }
}
