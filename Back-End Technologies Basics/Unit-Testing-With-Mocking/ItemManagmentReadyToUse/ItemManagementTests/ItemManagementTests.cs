using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Interfaces;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        private ItemService _itemService;
        private Mock<IItemRepository> _mockItemRepository; long _id;

        [SetUp]
        public void Setup()
        {
            // Arrange: Create a mock instance of IItemRepository
            _mockItemRepository = new Mock<IItemRepository>();
            
            // Instantiate ItemService with the mocked repository
            _itemService = new ItemService(_mockItemRepository.Object);
            
        }

        [Test]
        public void AddItem_ShouldCallAddItemOnRepository()
        {
            //Arrange
            var item = new Item { Name = "Test Item"};
            _mockItemRepository.Setup(x => x.AddItem(It.IsAny<Item>()));

            // Act: Call AddItem on the service
            _itemService.AddItem(item.Name);
            

            // Assert: Verify that AddItem was called on the repository
            _mockItemRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Once());
            
        }

        [Test]
        public void GetAllItems_ShouldReturnAllItems()
        {
            //Arrange
            var items = new List<Item>() { new Item { Id = 1, Name = "SampleItem", } };
            _mockItemRepository.Setup(x => x.GetAllItems()).Returns(items);

            //Act
            var result = _itemService.GetAllItems();

            //Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));
            _mockItemRepository.Verify(x => x.GetAllItems(), Times.Once());
            
        }

        [Test]
        public void UpdateItem_ShouldCallUpdateItemOnRepository()
        {
           
        }

        [Test]
        public void DeleteItem_ShouldCallDeleteItemOnRepository()
        {
            
        }

        [Test]
        public void ValidateItemName_WhenNameIsValid_ShouldReturnTrue()
        {
            //Arrange
            var validItem = new Item { Name = "True Item" };
            


            //Act
            //Assert

        }

        [Test]
        public void ValidateItemName_WhenNameIsTooLong_ShouldReturnFalse()
        {
            
        }

        [Test]
        public void ValidateItemName_WhenNameIsEmpty_ShouldReturnFalse()
        {
            
        }
    }
}