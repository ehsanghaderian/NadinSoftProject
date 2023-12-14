using Microsoft.OpenApi.Models;

internal class ApiKeyScheme : OpenApiSecurityScheme
{
    public string In { get; set; }
}