// Decompiled with JetBrains decompiler
// Type: Terraria.UI.SnapPoint
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI
{
  public class SnapPoint
  {
    private Vector2 _anchor;
    private Vector2 _offset;
    private Vector2 _calculatedPosition;
    private string _name;
    private int _id;
    public UIElement BoundElement;

    public string Name
    {
      get
      {
        return this._name;
      }
    }

    public int ID
    {
      get
      {
        return this._id;
      }
    }

    public Vector2 Position
    {
      get
      {
        return this._calculatedPosition;
      }
    }

    public SnapPoint(string name, int id, Vector2 anchor, Vector2 offset)
    {
      this._name = name;
      this._id = id;
      this._anchor = anchor;
      this._offset = offset;
    }

    public void Calculate(UIElement element)
    {
      this.BoundElement = element;
      CalculatedStyle dimensions = element.GetDimensions();
      this._calculatedPosition = dimensions.Position() + this._offset + this._anchor * new Vector2(dimensions.Width, dimensions.Height);
    }

    public override string ToString()
    {
      return "Snap Point - " + this.Name + " " + (object) this.ID;
    }
  }
}
