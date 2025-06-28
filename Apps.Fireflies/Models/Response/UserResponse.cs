using Newtonsoft.Json;

namespace Apps.Fireflies.Models.Response;

public class UserResponse
{
    public UserData Data { get; set; }
}

public class UserData
{
    public UserInfo User { get; set; }
}

public class UserInfo
{
    public string Name { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }
}
