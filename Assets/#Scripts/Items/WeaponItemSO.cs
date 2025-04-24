using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Items/Weapon")]
public class WeaponItemSO : ItemSO
{
    [Header("Taban Savaş İstatistikleri")]
    [SerializeField] private DamageType damageType = DamageType.Physical;
    [Min(1)][SerializeField] private float baseMinDamage = 3;
    [Min(1)][SerializeField] private float baseMaxDamage = 7;
    [Min(0.1f)][SerializeField] private float attacksPerSecond = 1.0f;

    [Header("Diğer")]
    [SerializeField] private int requiredLevel = 1;
    [SerializeField] private Sprite projectilePrefab;

    // --- Properties ---
    public DamageType DamageType => damageType;
    public float BaseMinDamage => baseMinDamage;
    public float BaseMaxDamage => baseMaxDamage;
    public float AttacksPerSecond => attacksPerSecond;
    public int RequiredLevel => requiredLevel;
    public Sprite ProjectilePrefab => projectilePrefab;
}

public enum DamageType { Physical, Fire, Cold, Lightning, Chaos }
