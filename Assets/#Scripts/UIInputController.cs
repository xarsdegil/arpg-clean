using System;
using UnityEngine;

public class UIInputController : MonoBehaviour
{
    [SerializeField] GameObject _activeSkillsCanvas, _inventoryCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Input_ActiveSkillsUI();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Input_InventoryUI();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_activeSkillsCanvas != null && _activeSkillsCanvas.activeSelf)
            {
                _activeSkillsCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
            else if (_inventoryCanvas != null && _inventoryCanvas.activeSelf)
            {
                _inventoryCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void Input_InventoryUI()
    {
        if (_inventoryCanvas == null)
        {
            Debug.LogError("Inventory Canvas is not assigned in the inspector.");
            return;
        }
        if (_inventoryCanvas.activeSelf)
        {
            _inventoryCanvas.SetActive(false);
            Time.timeScale = 1f;
            return;
        }
        _inventoryCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Input_ActiveSkillsUI()
    {

        if (_activeSkillsCanvas == null)
        {
            Debug.LogError("Active Skills Canvas is not assigned in the inspector.");
            return;
        }
        if (_activeSkillsCanvas.activeSelf)
        {
            _activeSkillsCanvas.SetActive(false);
            Time.timeScale = 1f; // Resume game time
            return;
        }
        UpdateActiveSkillsTooltip();
        _activeSkillsCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause game time

    }

    private void UpdateActiveSkillsTooltip()
    {

    }
}
