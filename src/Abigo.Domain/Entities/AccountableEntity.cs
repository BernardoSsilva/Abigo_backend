using Abigo.Domain.Models;

namespace Abigo.Domain.Entities
{
    public class AccountableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;
        public string contactEmail { get; set; } = string.Empty;
        public string contactPhone { get; set; } = string.Empty;
        public string instagram { get; set; } = string.Empty;
        public  string ConnectionEmail { get; set; } = string.Empty;

        public  string AccessPassword { get; set; } = string.Empty;


    }
}
