[System.Serializable]
public class InventorySlot
{
    public ItemBase item;
    public int count;

    public InventorySlot(ItemBase item, int count = 1)
    {
        this.item = item;
        this.count = count;
    }
}