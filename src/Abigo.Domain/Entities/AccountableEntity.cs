using Abigo.Domain.Models;

namespace Abigo.Domain.Entities
{
    public class AccountableEntity: BaseEntity
    {
        public required string  Name { get; set; }
        public List<ContactModel> Contacts { get; set; } = [];

        public required string ConnectionEmail { get; set; }

        public required string AccessPassword { get; set; }

    }
}
