using Abigo.Domain.Entities;
using System;
using Xunit;

namespace Abigo.Tests.Entities
{
    public class AccountablesEntityTests
    {

        [Fact]
        public void AccountableEntity_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var entity = new AccountableEntity();

            // Assert
            Assert.NotNull(entity.Id);
            Assert.False(string.IsNullOrWhiteSpace(entity.Id));
            Assert.Equal(string.Empty, entity.Name);
            Assert.Equal(string.Empty, entity.contactEmail);
            Assert.Equal(string.Empty, entity.contactPhone);
            Assert.Equal(string.Empty, entity.instagram);
            Assert.Equal(string.Empty, entity.ConnectionEmail);
            Assert.Equal(string.Empty, entity.AccessPassword);
        }

        [Fact]
        public void AccountableEntity_ShouldSetAndGetProperties()
        {
            // Arrange
            var entity = new AccountableEntity();
            var id = Guid.NewGuid().ToString();
            var name = "John Doe";
            var contactEmail = "john.doe@example.com";
            var contactPhone = "123456789";
            var instagram = "@johndoe";
            var connectionEmail = "connect@example.com";
            var accessPassword = "password123";

            // Act
            entity.Id = id;
            entity.Name = name;
            entity.contactEmail = contactEmail;
            entity.contactPhone = contactPhone;
            entity.instagram = instagram;
            entity.ConnectionEmail = connectionEmail;
            entity.AccessPassword = accessPassword;

            // Assert
            Assert.Equal(id, entity.Id);
            Assert.Equal(name, entity.Name);
            Assert.Equal(contactEmail, entity.contactEmail);
            Assert.Equal(contactPhone, entity.contactPhone);
            Assert.Equal(instagram, entity.instagram);
            Assert.Equal(connectionEmail, entity.ConnectionEmail);
            Assert.Equal(accessPassword, entity.AccessPassword);
        }
    }
}
