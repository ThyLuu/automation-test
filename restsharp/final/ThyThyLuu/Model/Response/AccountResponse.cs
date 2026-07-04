// public class AccountResponse
// {
//     public string? UserId { get; set; }

//     public string? Username { get; set; }

//     public List<AddBookResponse> Books { get; set; }
// }

public class AccountResponse
{
    public string? UserId { get; set; }

    public string? Username { get; set; }

    public List<BookItem>? Books { get; set; }
}