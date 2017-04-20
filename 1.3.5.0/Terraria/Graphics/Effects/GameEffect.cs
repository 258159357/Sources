// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.GameEffect
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;

namespace Terraria.Graphics.Effects
{
  public abstract class GameEffect
  {
    public float Opacity;
    protected bool _isLoaded;
    protected EffectPriority _priority;

    public bool IsLoaded
    {
      get
      {
        return this._isLoaded;
      }
    }

    public EffectPriority Priority
    {
      get
      {
        return this._priority;
      }
    }

    public void Load()
    {
      if (this._isLoaded)
        return;
      this._isLoaded = true;
      this.OnLoad();
    }

    public virtual void OnLoad()
    {
    }

    public abstract bool IsVisible();

    internal abstract void Activate(Vector2 position, params object[] args);

    internal abstract void Deactivate(params object[] args);
  }
}
