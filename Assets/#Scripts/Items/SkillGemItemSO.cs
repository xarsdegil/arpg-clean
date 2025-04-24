using UnityEngine;

[CreateAssetMenu(fileName = "NewSkillGem", menuName = "Items/Skill Gem")]
public class SkillGemItemSO : ItemSO
{
    [Header("Gem Verileri")]
    [SerializeField] private TextAsset skillLogic;
    [SerializeField] private int manaCost = 10;
    public Skill skill;
    public TextAsset SkillLogic => skillLogic;
    public int ManaCost => manaCost;
}
