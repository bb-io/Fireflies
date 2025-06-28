using Newtonsoft.Json;

namespace Apps.Fireflies.Models.Response;

public class UserResponse
{
    public UserData Data { get; set; } = new();
}

public class UserData
{
    public UserInfo User { get; set; } = new();
}

public class UserInfo
{
    public string Name { get; set; } = string.Empty;

    [JsonProperty("user_id")]
    public string UserId { get; set; } = string.Empty;
}
