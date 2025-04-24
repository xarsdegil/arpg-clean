using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item Base")]
public class ItemSO : ScriptableObject
{
    [Header("Kimlik")]
    [SerializeField] private string id = System.Guid.NewGuid().ToString();
    [SerializeField] private string displayName;
    [TextArea][SerializeField] private string description;
    [SerializeField] private Sprite icon;

    [Header("Temel")]
    [SerializeField] private ItemType itemType;
    [SerializeField] private Rarity rarity = Rarity.Common;
    [Min(1)][SerializeField] private int maxStack = 1;

    // --- Properties ---
    public string Id => id;
    public string DisplayName => displayName;
    public string Description => description;
    public Sprite Icon => icon;
    public ItemType ItemType => itemType;
    public Rarity Rarity => rarity;
    public int MaxStack => maxStack;
}
public enum Rarity { Common, Magic, Rare, Unique, Legendary }