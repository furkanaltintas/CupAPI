namespace CupAPI.API.Routing;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value) => value?.ToString().ToLowerInvariant();
}
