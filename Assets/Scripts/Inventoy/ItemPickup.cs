using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        //once the prefab of the item colides with the player, it adds the item to the inventory
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
