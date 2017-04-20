// Decompiled with JetBrains decompiler
// Type: Terraria.GameInput.TriggersPack
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Linq;

namespace Terraria.GameInput
{
  public class TriggersPack
  {
    public TriggersSet Current = new TriggersSet();
    public TriggersSet Old = new TriggersSet();
    public TriggersSet JustPressed = new TriggersSet();
    public TriggersSet JustReleased = new TriggersSet();

    public void Initialize()
    {
      this.Current.SetupKeys();
      this.Old.SetupKeys();
      this.JustPressed.SetupKeys();
      this.JustReleased.SetupKeys();
    }

    public void Reset()
    {
      this.Old = this.Current.Clone();
      this.Current.Reset();
    }

    public void Update()
    {
      this.CompareDiffs(this.JustPressed, this.Old, this.Current);
      this.CompareDiffs(this.JustReleased, this.Current, this.Old);
    }

    public void CompareDiffs(TriggersSet Bearer, TriggersSet oldset, TriggersSet newset)
    {
      Bearer.Reset();
      foreach (string index in Bearer.KeyStatus.Keys.ToList<string>())
        Bearer.KeyStatus[index] = newset.KeyStatus[index] && !oldset.KeyStatus[index];
    }
  }
}
