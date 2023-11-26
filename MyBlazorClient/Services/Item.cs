namespace MyBlazorClient.Services;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // 'required' keyword is not valid here for required fields
}