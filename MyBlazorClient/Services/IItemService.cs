namespace MyBlazorClient.Services;

public interface IItemService
{
    Task<Item> CreateItem(Item newItem);
    Task<List<Item>> GetItems();
    Task<Item> GetItemById(int id);
    Task<Item> EditItem(int id, Item updatedItem);

    Task<bool> DeleteItem(int id);
}



