using Business.Services;
using Data.Services;
using Domain.Models;
using Dtos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Test.Buisness
{
    public class ContactServiceTests
    {
        private readonly ContactService _contactService;
        private readonly Mock<FileService> _mockFileService;

        public ContactServiceTests()
        {
            _mockFileService = new Mock<FileService>();
            _contactService = new ContactService();
        }

        [Fact]
        public void Add_Should_Add_Contact_And_Save_To_File()
        {
            // Arrange
            var form = new ContactRegistrationForm
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "+1234567890",
                StreetAddress = "123 Main Street",
                PostalCode = "12345",
                City = "TestCity"
            };

            // Act
            _contactService.Add(form);
            var allContacts = _contactService.GetAll();

            // Assert
            Assert.Single(allContacts);
            Assert.Contains(allContacts, c => c.FirstName == "John" && c.LastName == "Doe");
        }

        

        [Fact]
        public void RemoveAll_Should_Clear_All_Contacts_And_Save_Empty_List()
        {
            // Act
            var success = _contactService.RemoveAll();

            // Assert
            Assert.True(success);
            Assert.Empty(_contactService.GetAll());
        }

        
    }
}
