// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.GameShaders
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Collections.Generic;

namespace Terraria.Graphics.Shaders
{
  public class GameShaders
  {
    public static ArmorShaderDataSet Armor = new ArmorShaderDataSet();
    public static HairShaderDataSet Hair = new HairShaderDataSet();
    public static Dictionary<string, MiscShaderData> Misc = new Dictionary<string, MiscShaderData>();
  }
}
