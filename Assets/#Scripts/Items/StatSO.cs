using UnityEngine;

public enum StatValueType { Flat, Percent }

[CreateAssetMenu(fileName = "NewStat", menuName = "Stats/Stat")]
public class StatSO : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private StatValueType valueType;

    [SerializeField] private Sprite icon;

    public string DisplayName => displayName;
    public StatValueType ValueType => valueType;
    public Sprite Icon => icon;
}
