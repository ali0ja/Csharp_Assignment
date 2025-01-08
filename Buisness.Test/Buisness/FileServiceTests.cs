using Data.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Test.Buisness
{
    public class FileServiceTests
    {
        private readonly string _testDirectory = "TestData";
        private readonly string _testFile = "test.json";
        private readonly FileService _fileService;

        public FileServiceTests()
        {
            _fileService = new FileService(_testDirectory, _testFile);
        }

        [Fact]
        public void SaveListToFile_Should_Create_File_And_Save_Data()
        {
            // Arrange
            var contacts = new List<Contact>
        {
            new Contact { FirstName = "John", LastName = "Doe" }
        };

            // Act
            _fileService.SaveListToFile(contacts);

            // Assert
            Assert.True(File.Exists(Path.Combine(_testDirectory, _testFile)));
        }

        [Fact]
        public void LoadListFromFile_Should_Return_Saved_Data()
        {
            // Arrange
            var contacts = new List<Contact>
        {
            new Contact { FirstName = "John", LastName = "Doe" }
        };
            _fileService.SaveListToFile(contacts);

            // Act
            var result = _fileService.LoadListFromFile();

            // Assert
            Assert.Single(result);
            Assert.Equal("John", result[0].FirstName);
        }
    }
}
