// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.HairShaderDataSet
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class HairShaderDataSet
  {
    protected List<HairShaderData> _shaderData = new List<HairShaderData>();
    protected Dictionary<int, short> _shaderLookupDictionary = new Dictionary<int, short>();
    protected byte _shaderDataCount;

    public T BindShader<T>(int itemId, T shaderData) where T : HairShaderData
    {
      if ((int) this._shaderDataCount == (int) byte.MaxValue)
        throw new Exception("Too many shaders bound.");
      Dictionary<int, short> lookupDictionary = this._shaderLookupDictionary;
      int index = itemId;
      byte num1 = (byte) ((uint) this._shaderDataCount + 1U);
      this._shaderDataCount = num1;
      int num2 = (int) num1;
      lookupDictionary[index] = (short) num2;
      this._shaderData.Add((HairShaderData) shaderData);
      return shaderData;
    }

    public void Apply(short shaderId, Player player, DrawData? drawData = null)
    {
      if ((int) shaderId != 0 && (int) shaderId <= (int) this._shaderDataCount)
        this._shaderData[(int) shaderId - 1].Apply(player, drawData);
      else
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public Color GetColor(short shaderId, Player player, Color lightColor)
    {
      if ((int) shaderId != 0 && (int) shaderId <= (int) this._shaderDataCount)
        return this._shaderData[(int) shaderId - 1].GetColor(player, lightColor);
      return new Color(lightColor.ToVector4() * player.hairColor.ToVector4());
    }

    public HairShaderData GetShaderFromItemId(int type)
    {
      if (this._shaderLookupDictionary.ContainsKey(type))
        return this._shaderData[(int) this._shaderLookupDictionary[type] - 1];
      return (HairShaderData) null;
    }

    public short GetShaderIdFromItemId(int type)
    {
      if (this._shaderLookupDictionary.ContainsKey(type))
        return this._shaderLookupDictionary[type];
      return -1;
    }
  }
}
