using Newtonsoft.Json;

namespace Apps.Fireflies.Models.Response
{
    public class UsersDatahandlerResponse
    {
        public UserDatahandlerData Data { get; set; } = new();
    }

    public class UserDatahandlerData
    {
        public IEnumerable<UserDatahandler> Users { get; set; } = new List<UserDatahandler>();
    }

    public class UserDatahandler
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
