using Abigo.Communication.Responses.AvailableLocales;

namespace Abigo.Communication.Responses.DisponibleLocales
{
    public class MultipleLocalesResponseJson
    {
        public List<AvailableLocalesShortResponseJson> Locales { get; set; } = [];
    }
}
