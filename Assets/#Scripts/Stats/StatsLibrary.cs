using UnityEngine;

public static class StatLibrary
{
    public static readonly StatSO PercentDamage = Load("PercentDamage");
    //public static readonly StatSO FireResistance = Load("FireResistance");
    public static readonly StatSO Strength = Load("Strength");

    private static StatSO Load(string assetName)
        => Resources.Load<StatSO>($"Stats/{assetName}");
}
