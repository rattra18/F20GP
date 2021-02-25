using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Text text;
    public Text itemText;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        string path;
        ImagesDictionary.itemsSprite.TryGetValue(item.iconID, out path);
        icon.sprite = Resources.Load<Sprite>("Sprites/" + path);
        icon.gameObject.SetActive(true);
        removeButton.interactable = true;
        text.gameObject.SetActive(true);
        itemText.text = item.name;
        itemText.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        removeButton.interactable = false;
        text.gameObject.SetActive(false);
        itemText.text = null;
        itemText.gameObject.SetActive(false);
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
}
