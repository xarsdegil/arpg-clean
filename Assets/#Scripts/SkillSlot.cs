using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public Skill _skill;

    [SerializeField] Image _skillIcon, _supportIcon1, _supportIcon2, _supportIcon3;
    [SerializeField] TMP_Text _skillNameText, _dpsText;
    [SerializeField] Button _detailsButton;

    public void SetSkillSlot(Skill skill)
    {
        _skill = skill;
        _skillIcon.sprite = skill.icon;
        _skillNameText.text = skill.skillName;
        _dpsText.text = CalculateDps(skill);
    }

    private string CalculateDps(Skill skill)
    {
        float dps = skill.damage / skill.cooldown;
        return $"{dps:F2}";
    }
}
