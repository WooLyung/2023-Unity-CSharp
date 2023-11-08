using UnityEngine;
using static Inventory;

public class InventoryUI : MonoBehaviour, Observer
{
    [SerializeField]
    private Inventory inventory;

    public void Start()
    {
        inventory.AddObserver(this);

        // Test
        inventory.ChangeSlot(0, "item1", 5);
        inventory.ChangeSlot(1, "item2", 10);
    }

    public void OnSlotChanged(int slot, string name, uint count)
    {
        Debug.Log((slot, name, count));
    }

    public void OnRegister((string, uint)[] inventory)
    {
    }
}
