﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Cinematics.CinematicManager
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.Cinematics
{
  public class CinematicManager
  {
    public static CinematicManager Instance = new CinematicManager();
    private List<Film> _films = new List<Film>();

    public void Update(GameTime gameTime)
    {
      if (this._films.Count <= 0)
        return;
      if (!this._films[0].IsActive)
        this._films[0].OnBegin();
      if (!Main.hasFocus || Main.gamePaused || this._films[0].OnUpdate(gameTime))
        return;
      this._films[0].OnEnd();
      this._films.RemoveAt(0);
    }

    public void PlayFilm(Film film)
    {
      this._films.Add(film);
    }

    public void StopAll()
    {
    }
  }
}
