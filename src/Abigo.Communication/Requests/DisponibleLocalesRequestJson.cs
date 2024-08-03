using Abigo.Domain.Enums;

namespace Abigo.Communication.Requests
{
    public class AvailableLocalesRequestJson
    {
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public UFS UF { get; set; }
        public string NeighboorHood { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string LocaleNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public Boolean AcceptsAnimals { get; set; }

        public int VacanciesNumber { get; set; } = 0;

        public string contactEmail { get; set; } = string.Empty;
        public string contactPhone { get; set; } = string.Empty;
        public string instagram { get; set; } = string.Empty;

        public string DonationKey { get; set; } = string.Empty;

        public string ReferencePoint { get; set; } = string.Empty;

        public LocalesCategories Category { get; set; }

        public bool IsActive { get; set; }

        public string LocaleName { get; set; } = string.Empty;
    }
}
