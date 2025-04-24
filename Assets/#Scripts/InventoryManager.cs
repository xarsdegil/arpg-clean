using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [Header("Referanslar")]
    [SerializeField] private UI_Inventory ui;

    [Header("Demo Gem")]
    [SerializeField] private SkillGemItemSO gemTemplate;

    private readonly List<ItemInstance> items = new();

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            SpawnGem();
    }

    /*------------ Kamu API ------------*/
    public void UseItem(ItemInstance inst)
    {
        switch (inst.Template.ItemType)
        {
            case ItemType.SkillGem:
                UseSkillGem(inst);
                break;
        }
    }

    public bool AddItem(ItemInstance inst)
    {
        items.Add(inst);
        ui.Refresh(items);
        return true;
    }

    /*------------ Demo Gem ------------*/
    private void SpawnGem()
    {
        var inst = new ItemInstance(gemTemplate, new RolledAffix[0]);
        Debug.Log(inst.Template.DisplayName);
        AddItem(inst);
        Debug.Log($"[Demo] {gemTemplate.DisplayName} envantere eklendi (H tuşu).");
    }


    private void UseSkillGem(ItemInstance inst)
    {
        items.Remove(inst);
        ui.Refresh(items);

        Debug.Log(items.Count + " item(s) in inventory.");

        ActiveSkillManager.Instance.AddSkill(inst);
    }
}
