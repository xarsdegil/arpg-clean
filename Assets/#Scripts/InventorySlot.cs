using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] Sprite _initialSprite;
    private ItemInstance item;

    private void Awake()
    {
        _initialSprite = icon.sprite;
    }

    public void SetItem(ItemInstance inst)
    {
        item = inst;
        icon.sprite = inst.Template.Icon;
        icon.enabled = true;
    }
    public void Clear()
    {
        item = null;
        icon.sprite = _initialSprite;
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Right && item != null)
            InventoryManager.Instance.UseItem(item);
    }
}
