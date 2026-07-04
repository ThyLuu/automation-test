public class AddBookRequest
{
    public string? UserId { get; set; }

    public List<IsbnItem>? CollectionOfIsbns { get; set; }
}

public class IsbnItem
{
    public string? Isbn { get; set; }
}