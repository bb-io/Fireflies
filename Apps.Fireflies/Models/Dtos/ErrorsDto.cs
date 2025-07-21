namespace Apps.Fireflies.Models.Dtos;

public class ErrorsDto
{
    public List<ErrorDto> Errors { get; set; } = new();

    public override string ToString()
    {
        return string.Join(", ", Errors.Select(e => $"{e.Code}: {e.Message}"));
    }
}

public class ErrorDto
{
    public bool Friendly { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}