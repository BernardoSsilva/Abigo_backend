using Abigo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abigo.Communication.Responses.AvailableLocales
{
    public class AvailableLocalesShortResponseJson
    {
        public string Id { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string NeighboorHood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int VacanciesNumber { get; set; } = 0;
        public string contactPhone { get; set; } = string.Empty;

        public string DonationKey { get; set; } = string.Empty;
        public LocalesCategories Category { get; set; }
        public bool IsActive { get; set; }
    }
}
