using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject slotPrefab;

    Inventory inventory;

    InventorySlot[] slots;
    public GameObject[] slotsCopies = new GameObject[1000];
    public RectTransform rt;
    public float yHeight;
    public float xWidth;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        rt = itemsParent.GetComponent<RectTransform>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        //calculates the size of the inventory based on the screen
        yHeight = rt.sizeDelta.y;
        xWidth = rt.sizeDelta.x;
        NumSlots();
    }

    public void NumSlots()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        NumSlots();
        //continuosly checks if more items have been added to the inventory, as the number of slots would increase or decrease
        if(slots.Length != inventory.items.Count)
        {
            ChangeNumSlots();
        }
        UpdateUI();
    }

    public void ChangePanelSize()
    {
        NumSlots();
        if(slots.Length > 24)
        {
            //adjusts the panel size of the inventory to the number of slots that are occupied
            float numRows = Mathf.Ceil(slots.Length / 4f) - 6;
            rt.sizeDelta = new Vector2 (xWidth, yHeight + numRows * 240);
        }

        if(slots.Length <= 24)
        {
            rt.sizeDelta = new Vector2 (xWidth, yHeight);
        }
    }

    public void ChangeNumSlots()
    {
        //creates the prefab of the item for the number of slots in the inventory
        //producing them in order of id
        if(slots.Length < inventory.items.Count)
        {
            slotsCopies[i] = Instantiate(slotPrefab) as GameObject;
            slotsCopies[i].transform.SetParent(itemsParent);
            i++;
        } else if(slots.Length > inventory.items.Count)
        {
            GameObject tempSlot = slotsCopies[i];
            slotsCopies[i] = null;
            Destroy(tempSlot);
            if(i != 0)
            {
                i--;
            }
        }
        ChangePanelSize();
    }

    void UpdateUI()
    {
        //as the invetory screen will freeze the game, an additional update needs to be called to change the inventories UI
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else 
            {
                slots[i].ClearSlot();
            }
        }
    }
}
