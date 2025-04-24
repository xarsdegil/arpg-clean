using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemInstance
{
    [SerializeField] private ItemSO template;
    [SerializeField] private RolledAffix[] affixes;
    public ItemSO Template => template;
    public RolledAffix[] Affixes => affixes;

    public ItemInstance(ItemSO template, RolledAffix[] affixes)
    {
        this.template = template;
        this.affixes = affixes;
    }

    public int TotalStrength => affixes.Where(a => a.Stat == StatLibrary.Strength)
                                          .Sum(a => a.Value);
    public int PercentDamage => affixes.Where(a => a.Stat == StatLibrary.PercentDamage)
                                          .Sum(a => a.Value);
}

[Serializable]
public struct RolledAffix
{
    public StatSO Stat;
    public int Value;
}
