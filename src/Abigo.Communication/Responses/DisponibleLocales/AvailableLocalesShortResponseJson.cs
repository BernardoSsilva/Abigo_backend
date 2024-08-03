using Abigo.Domain.Enums;

namespace Abigo.Communication.Responses.AvailableLocales
{
    public class AvailableLocalesShortResponseJson
    {
        public string LocaleName { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string NeighboorHood { get; set; } = string.Empty;
        public int VacanciesNumber { get; set; } = 0;
        public string contactPhone { get; set; } = string.Empty;

        public string DonationKey { get; set; } = string.Empty;
        public LocalesCategories Category { get; set; }
        public bool IsActive { get; set; }
    }
}
