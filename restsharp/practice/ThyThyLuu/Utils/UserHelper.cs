using System.Text.Json;

public static class UserHelper
{
    public static int GetUserIdByEmail(string responseContent, string expectedEmail)
    {
        using JsonDocument document = JsonDocument.Parse(responseContent);

        JsonElement root = document.RootElement;

        foreach (JsonElement user in root.EnumerateArray())
        {
            string email =
                user.GetProperty("email").GetString()!;

            if (email.Equals(
                expectedEmail,
                StringComparison.OrdinalIgnoreCase))
            {
                return user
                    .GetProperty("id")
                    .GetInt32();
            }
        }

        throw new Exception($"Cannot find user email: {expectedEmail}");
    }
}