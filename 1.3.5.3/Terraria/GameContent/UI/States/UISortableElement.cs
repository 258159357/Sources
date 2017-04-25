// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UISortableElement
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Terraria.UI;

namespace Terraria.GameContent.UI.States
{
  public class UISortableElement : UIElement
  {
    public int OrderIndex;

    public UISortableElement(int index)
    {
      this.OrderIndex = index;
    }

    public override int CompareTo(object obj)
    {
      UISortableElement uiSortableElement = obj as UISortableElement;
      if (uiSortableElement != null)
        return this.OrderIndex.CompareTo(uiSortableElement.OrderIndex);
      return base.CompareTo(obj);
    }
  }
}
