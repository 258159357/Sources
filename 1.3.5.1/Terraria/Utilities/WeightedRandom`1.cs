// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.WeightedRandom`1
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Utilities
{
  public class WeightedRandom<T>
  {
    public readonly List<Tuple<T, double>> elements = new List<Tuple<T, double>>();
    public bool needsRefresh = true;
    public readonly UnifiedRandom random;
    private double _totalWeight;

    public WeightedRandom()
    {
      this.random = new UnifiedRandom();
    }

    public WeightedRandom(int seed)
    {
      this.random = new UnifiedRandom(seed);
    }

    public WeightedRandom(UnifiedRandom random)
    {
      this.random = random;
    }

    public WeightedRandom(params Tuple<T, double>[] theElements)
    {
      this.random = new UnifiedRandom();
      this.elements = ((IEnumerable<Tuple<T, double>>) theElements).ToList<Tuple<T, double>>();
    }

    public WeightedRandom(int seed, params Tuple<T, double>[] theElements)
    {
      this.random = new UnifiedRandom(seed);
      this.elements = ((IEnumerable<Tuple<T, double>>) theElements).ToList<Tuple<T, double>>();
    }

    public WeightedRandom(UnifiedRandom random, params Tuple<T, double>[] theElements)
    {
      this.random = random;
      this.elements = ((IEnumerable<Tuple<T, double>>) theElements).ToList<Tuple<T, double>>();
    }

    public static implicit operator T(WeightedRandom<T> weightedRandom)
    {
      return weightedRandom.Get();
    }

    public void Add(T element, double weight = 1.0)
    {
      this.elements.Add(new Tuple<T, double>(element, weight));
      this.needsRefresh = true;
    }

    public T Get()
    {
      if (this.needsRefresh)
        this.CalculateTotalWeight();
      double num = this.random.NextDouble() * this._totalWeight;
      using (List<Tuple<T, double>>.Enumerator enumerator = this.elements.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          Tuple<T, double> current = enumerator.Current;
          if (num <= current.get_Item2())
            return current.get_Item1();
          num -= current.get_Item2();
        }
      }
      return default (T);
    }

    public void CalculateTotalWeight()
    {
      this._totalWeight = 0.0;
      using (List<Tuple<T, double>>.Enumerator enumerator = this.elements.GetEnumerator())
      {
        while (enumerator.MoveNext())
          this._totalWeight += enumerator.Current.get_Item2();
      }
      this.needsRefresh = false;
    }

    public void Clear()
    {
      this.elements.Clear();
    }
  }
}
