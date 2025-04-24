using UnityEngine;

[CreateAssetMenu(fileName = "NewAffix", menuName = "Items/Affix")]
public class AffixSO : ScriptableObject
{
    [SerializeField] private string affixName;
    [SerializeField] private bool isPrefix;
    [SerializeField] private ItemType[] validTypes;

    [SerializeField] private AffixStatTier[] tiers;

    public string AffixName => affixName;
    public bool IsPrefix => isPrefix;
    public ItemType[] ValidTypes => validTypes;
    public AffixStatTier[] Tiers => tiers;

    [System.Serializable]
    public struct AffixStatTier
    {
        public StatSO stat;
        public int minValue;
        public int maxValue;
        public int requiredItemLevel;
        public int weight;
    }
}
