
using System.Net.Http.Json;

namespace MyBlazorClient.Services;

public class ItemService : IItemService
{
    private readonly HttpClient _httpClient;

    public ItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Item> CreateItem(Item newItem)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5185/api/items", newItem);

        if (response.IsSuccessStatusCode)
        {
            var createdItem = await response.Content.ReadFromJsonAsync<Item>();
            return createdItem!;
        }
        else
        {
            // Handle error scenario
            return null!;
        }
    }


    public async Task<List<Item>> GetItems()
    {
        var response = await _httpClient.GetAsync("http://localhost:5185/api/items");
        if (response.IsSuccessStatusCode)
        {
            var items = await response.Content.ReadFromJsonAsync<List<Item>>();
            return items!;
        }
        else
        {
            // Handle error scenario
            return [];
        }
    }

    public async Task<Item> GetItemById(int id)
    {
        var response = await _httpClient.GetAsync("http://localhost:5185/api/items/" + id);

        if (response.IsSuccessStatusCode)
        {
            var item = await response.Content.ReadFromJsonAsync<Item>();
            return item!;
        }
        else
        {
            return null!;
        }
    }

    public async Task<Item> EditItem(int id, Item updatedItem)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"http://localhost:5185/api/items/{id}");
        request.Content = JsonContent.Create(updatedItem);

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            // Jika Anda tidak mengharapkan respons dari server, cukup kembalikan updatedItem
            return updatedItem;
        }
        else
        {
            // Handle error scenario
            // Anda dapat menambahkan penanganan kesalahan khusus di sini
            return null;
        }
    }


    public async Task<bool> DeleteItem(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5185/api/items/{id}");

        return response.IsSuccessStatusCode;
    }


}
