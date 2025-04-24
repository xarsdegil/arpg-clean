using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSkillManager : MonoBehaviour
{
    public static ActiveSkillManager Instance { get; private set; }

    public int maxActiveSkills = 4;
    public List<Skill> skills = new List<Skill>();

    private Dictionary<Skill, float> cooldownTimers = new Dictionary<Skill, float>();

    public Transform activeSkillsPanel;
    public GameObject skillSlotPrefab;

    // brasi dinamiklestirilecek
    public Image bottomBarImage;
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (Skill skill in skills)
        {
            cooldownTimers[skill] = 0f;
        }
    }

    private void Update()
    {
        List<Skill> keys = new List<Skill>(cooldownTimers.Keys);
        foreach (Skill skill in keys)
        {
            if (cooldownTimers[skill] > 0f)
            {
                cooldownTimers[skill] -= Time.deltaTime;
                bottomBarImage.transform.Find("CooldownImage").GetComponent<Image>().fillAmount = cooldownTimers[skill] / skill.cooldown;
            }
        }
    }

    public bool CanUseSkill(Skill skill)
    {
        return cooldownTimers.ContainsKey(skill) && cooldownTimers[skill] <= 0f;
    }

    public void UseSkill(Skill skill)
    {
        if (CanUseSkill(skill))
        {
            skill.Execute(gameObject);
            cooldownTimers[skill] = skill.cooldown;

            bottomBarImage.transform.Find("CooldownImage").GetComponent<Image>().fillAmount = 1f;
        }
        else
        {
            Debug.Log($"{skill.skillName} henüz hazır değil!");
        }
    }

    public void AddSkill(ItemInstance inst)
    {
        if (inst.Template is SkillGemItemSO gem)
        {
            if (skills.Count < maxActiveSkills)
            {
                Skill newSkill = gem.skill;
                skills.Add(newSkill);

                GameObject skillSlot = Instantiate(skillSlotPrefab, activeSkillsPanel);
                skillSlot.GetComponent<SkillSlot>().SetSkillSlot(newSkill);

                bottomBarImage.sprite = newSkill.icon;
                bottomBarImage.transform.Find("CooldownImage").GetComponent<Image>().fillAmount = 0f;

                cooldownTimers[newSkill] = 0f;
            }
            else
            {
                Debug.Log("Maksimum beceri sayısına ulaşıldı.");
            }
        }
        else
        {
            Debug.LogError("Geçersiz beceri gemi.");
        }
    }
}
