using Apps.Fireflies.DataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Fireflies.Events.Models;

public class PollingTranscriptsRequest
{
    [Display("User ID")]
    [DataSource(typeof(UsersDataHandler))]
    public string? UserId { get; set; }

    [Display("Ignore calls if all participants from email domain")]
    public string? IgnoreWhenAllFromEmailDomain { get; set; }

    [Display("Ignore calls with titles containing")]
    public IEnumerable<string>? IgnoreWhenTitleContains { get; set; }
}
