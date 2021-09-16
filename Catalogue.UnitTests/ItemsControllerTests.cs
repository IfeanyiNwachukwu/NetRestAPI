// using System;
// using Xunit;
// using Moq;
// using CatalogueDash.Repositories;
// using CatalogueDash.Entities;
// using Microsoft.Extensions.Logging;
// using CatalogueDash.Controllers;
// using AutoMapper;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using CatalogueDash.Dtos.Readable;
// using FluentAssertions;
// using CatalogueDash.AutoMapper;
// using System.Collections.Generic;
// using CatalogueDash.Dtos.Writable;
// using CatalogueDash.Dtos.TestDTO;

// namespace Catalogue.UnitTests
// {
//     public class ItemsControllerTests
//     {
//         private readonly Mock<IItemsRepository> repositoryStub = new();
//         private readonly  Mock<ILogger<ItemsController>> loggerStub = new();
//         private readonly Random rand = new();
//         private static IMapper _mapper;


//         public ItemsControllerTests()
//         {
//               if (_mapper == null)
//             {
//                 var mappingConfig = new MapperConfiguration(mc =>
//                 {
//                     mc.AddProfile(new MappingProfile());
//                 });
//                 IMapper mapper = mappingConfig.CreateMapper();
//                 _mapper = mapper;
//             }
//         }
      
//         //UnitOfWork_StateUnderTest_ExpectedBehaviour  --- Test Naming Convention
//         [Fact]
//         public async Task GetItemAsync_WithUnexistingItem_ReturnsNotFound()
//         {
//             // Arrange
//             repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
//                 .ReturnsAsync((Item)null);

//             var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             var result = await controller.GetItemAsync(Guid.NewGuid());

//             // Assert
//             result.Result.Should().BeOfType<NotFoundResult>();
//         }

//         [Fact]
//         public async Task GetItemAsync_WithExistingItem_ReturnsExpectedItem()
//         {
//             // Arrange
//             Item expectedItem = CreateRandomItem();

//             repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
//                 .ReturnsAsync(expectedItem);

//              var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             var result = await controller.GetItemAsync(Guid.NewGuid());

//             // Assert
//             result.Value.Should().BeEquivalentTo(expectedItem);
//         }

//         [Fact]
//         public async Task GetItemsAsync_WithExistingItems_ReturnsAllItems()
//         {
//             // Arrange
//             var expectedItems = new[] { CreateRandomItem(), CreateRandomItem(), CreateRandomItem() };

//             repositoryStub.Setup(repo => repo.GetItemsAsync())
//                 .ReturnsAsync(expectedItems);

//              var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             var actualItems = await controller.GetItemsAsync();

//             // Assert
//             actualItems.Should().BeEquivalentTo(expectedItems);
//         }

//         [Fact]
//         public async Task GetItemsAsync_WithMatchingItems_ReturnsMatchingItems()
//         {
//             // Arrange
//             var allItems = new[]
//             {
//                 new Item(){ Name = "Potion"},
//                 new Item(){ Name = "Antidote"},
//                 new Item(){ Name = "Hi-Potion"}
//             };

//             var nameToMatch = "Potion";

//             repositoryStub.Setup(repo => repo.GetItemsAsync())
//                 .ReturnsAsync(allItems);

//             var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             IEnumerable<ItemDto> foundItems = await controller.GetItemsAsync(nameToMatch);

//             // Assert
//             foundItems.Should().OnlyContain(
//                 item => item.Name == allItems[0].Name || item.Name == allItems[2].Name
//             );
//         }

//         [Fact]
//         public async Task CreateItemAsync_WithItemToCreate_ReturnsCreatedItem()
//         {
//             // Arrange
//             var itemToCreate = new CreateItemDto(
//                 Guid.NewGuid().ToString(),
//                 Guid.NewGuid().ToString(),
//                 rand.Next(1000));

//              var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             var result = await controller.CreateItemAsync(itemToCreate);

//             // Assert
//             var createdItem = (result.Result as CreatedAtActionResult).Value as ItemDto;
//             itemToCreate.Should().BeEquivalentTo(
//                 createdItem,
//                 options => options.ComparingByMembers<ItemDto>().ExcludingMissingMembers()
//             );
//             createdItem.Id.Should().NotBeEmpty();
//             createdItem.CreatedDate.Should().BeCloseTo(DateTimeOffset.UtcNow, 1000);
//         }

//         [Fact]
//         public async Task UpdateItemAsync_WithExistingItem_ReturnsNoContent()
//         {
//             // Arrange
//             Item existingItem = CreateRandomItem();
//             repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
//                 .ReturnsAsync(existingItem);

//             var itemId = existingItem.Id;
//             var itemToUpdate = new UpdateItemDto(
//                 Guid.NewGuid().ToString(),
//                 Guid.NewGuid().ToString(),
//                 existingItem.Price + 3
//             );

//              var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             var result = await controller.UpdateItemAsync(itemId, itemToUpdate);

//             // Assert
//             result.Should().BeOfType<NoContentResult>();
//         }

//         [Fact]
//         public async Task DeleteItemAsync_WithExistingItem_ReturnsNoContent()
//         {
//             // Arrange
//             Item existingItem = CreateRandomItem();
//             repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
//                 .ReturnsAsync(existingItem);

//              var controller = new ItemsController(repositoryStub.Object,_mapper, loggerStub.Object);

//             // Act
//             var result = await controller.DeleteItemAsync(existingItem.Id);

//             // Assert
//             result.Should().BeOfType<NoContentResult>();
//         }

//         private Item CreateRandomItem()
//         {
//             return new()
//             {
//                 Id = Guid.NewGuid(),
//                 Name = Guid.NewGuid().ToString(),
//                 Price = rand.Next(1000),
//                 CreatedDate = DateTimeOffset.UtcNow
//             };
//         }
//     }
// }
