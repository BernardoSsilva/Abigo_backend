using Abigo.Domain.Enums;
using Abigo.Domain.Models;
using System.Numerics;

namespace Abigo.Domain.Entities
{
    public class AvailableLocalesEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string AccountId { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public required UFS UF { get; set; }
        public required string NeighboorHood { get; set; }

        public required string Street { get; set; }

        public string LocaleNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public required Boolean AcceptsAnimals { get; set; }

        public int VacanciesNumber { get; set; } = 0;

        public string contactEmail { get; set; } = string.Empty;
        public string contactPhone { get; set; } = string.Empty;
        public string instagram { get; set; } = string.Empty;

        public string DonationKey { get; set; } = string.Empty;

        public string ReferencePoint { get; set; } = string.Empty;

        public LocalesCategories Category { get; set; }

        public bool IsActive { get; set; }

        public required string LocaleName { get; set; }


    }
}
