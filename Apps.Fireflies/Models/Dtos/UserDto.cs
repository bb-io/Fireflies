using Newtonsoft.Json;

namespace Apps.Fireflies.Models.Dtos;

public class UserDto
{
    [JsonProperty("user_id")]
    public string UserId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}

public class UserApiResponseDto
{
    public UserApiResponseData Data { get; set; } = new();
}

public class UserApiResponseData
{
    public UserDto User { get; set; } = new();
}

public class UsersApiResponseDto
{
    public UsersApiResponseData Data { get; set; } = new();
}

public class UsersApiResponseData
{
    public IEnumerable<UserDto> Users { get; set; } = [];
}
