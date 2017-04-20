// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Shaders.MoonLordScreenShaderData
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
  public class MoonLordScreenShaderData : ScreenShaderData
  {
    private int _moonLordIndex = -1;

    public MoonLordScreenShaderData(string passName)
      : base(passName)
    {
    }

    private void UpdateMoonLordIndex()
    {
      if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
        return;
      int num = -1;
      for (int index = 0; index < Main.npc.Length; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == 398)
        {
          num = index;
          break;
        }
      }
      this._moonLordIndex = num;
    }

    public override void Apply()
    {
      this.UpdateMoonLordIndex();
      if (this._moonLordIndex != -1)
        this.UseTargetPosition(Main.npc[this._moonLordIndex].Center);
      base.Apply();
    }
  }
}
