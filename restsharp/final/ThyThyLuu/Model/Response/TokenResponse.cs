using System.Text.Json.Serialization;

public class TokenResponse
{
    [JsonPropertyName("token")]
    public string? Token { get; set; } 

    [JsonPropertyName("expires")]
    public string? Expires { get; set; } 

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("result")]
    public string? Result { get; set; }
}