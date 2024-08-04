using Abigo.Domain.Entities;
using Abigo.Domain.Enums;
using Xunit;

namespace Abigo.Tests.Entities
{
    public class AvailableLocalesEntityTests
    {
        [Fact]
        public void AvailableLocalesEntity_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var entity = new AvailableLocalesEntity
            {
                AccountId = "Account1",
                PostalCode = "12345",
                City = "SampleCity",
                UF = UFS.SP,
                NeighboorHood = "SampleNeighboorHood",
                Street = "SampleStreet",
                AcceptsAnimals = true,
                LocaleName = "SampleLocale"
            };

            // Assert
            Assert.NotNull(entity.Id);
            Assert.False(string.IsNullOrWhiteSpace(entity.Id));
            Assert.Equal("Account1", entity.AccountId);
            Assert.Equal("12345", entity.PostalCode);
            Assert.Equal("SampleCity", entity.City);
            Assert.Equal(UFS.SP, entity.UF);
            Assert.Equal("SampleNeighboorHood", entity.NeighboorHood);
            Assert.Equal("SampleStreet", entity.Street);
            Assert.Equal(string.Empty, entity.LocaleNumber);
            Assert.Equal(string.Empty, entity.Description);
            Assert.True(entity.AcceptsAnimals);
            Assert.Equal(0, entity.VacanciesNumber);
            Assert.Equal(string.Empty, entity.contactEmail);
            Assert.Equal(string.Empty, entity.contactPhone);
            Assert.Equal(string.Empty, entity.instagram);
            Assert.Equal(string.Empty, entity.DonationKey);
            Assert.Equal(string.Empty, entity.ReferencePoint);
            Assert.Equal(string.Empty, entity.HelpDescription);
            Assert.Equal(LocalesCategories.None, entity.Category);
            Assert.False(entity.IsActive);
            Assert.Equal("SampleLocale", entity.LocaleName);
        }

        [Fact]
        public void AvailableLocalesEntity_ShouldSetAndGetProperties()
        {
            // Arrange
            var entity = new AvailableLocalesEntity
            {
                AccountId = "Account1",
                PostalCode = "12345",
                City = "SampleCity",
                UF = UFS.SP,
                NeighboorHood = "SampleNeighboorHood",
                Street = "SampleStreet",
                AcceptsAnimals = true,
                LocaleName = "SampleLocale"
            };

            var id = Guid.NewGuid().ToString();
            var localeNumber = "100";
            var description = "Sample Description";
            var vacanciesNumber = 10;
            var contactEmail = "contact@example.com";
            var contactPhone = "123456789";
            var instagram = "@example";
            var donationKey = "donationKey";
            var referencePoint = "Near Park";
            var helpDescription = "Need help with groceries";
            var category = LocalesCategories.Food;
            var isActive = true;

            // Act
            entity.Id = id;
            entity.LocaleNumber = localeNumber;
            entity.Description = description;
            entity.VacanciesNumber = vacanciesNumber;
            entity.contactEmail = contactEmail;
            entity.contactPhone = contactPhone;
            entity.instagram = instagram;
            entity.DonationKey = donationKey;
            entity.ReferencePoint = referencePoint;
            entity.HelpDescription = helpDescription;
            entity.Category = category;
            entity.IsActive = isActive;

            // Assert
            Assert.Equal(id, entity.Id);
            Assert.Equal(localeNumber, entity.LocaleNumber);
            Assert.Equal(description, entity.Description);
            Assert.Equal(vacanciesNumber, entity.VacanciesNumber);
            Assert.Equal(contactEmail, entity.contactEmail);
            Assert.Equal(contactPhone, entity.contactPhone);
            Assert.Equal(instagram, entity.instagram);
            Assert.Equal(donationKey, entity.DonationKey);
            Assert.Equal(referencePoint, entity.ReferencePoint);
            Assert.Equal(helpDescription, entity.HelpDescription);
            Assert.Equal(category, entity.Category);
            Assert.True(entity.IsActive);
        }
    }
}

