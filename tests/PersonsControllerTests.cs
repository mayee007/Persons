using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using FluentAssertions;
using System;
using Moq;
using Persons.Models; 
using Persons.Controllers; 

namespace Persons.tests 
{
    public class PersonsControllerTests 
    {
        [Fact]
        public async Task Values_Get_All()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            persons.Count().Should().Be(50);
        }

        [Fact]
        public async Task Values_Get_Specific()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());

            // Act
            var result = await controller.Get(16);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(16);
        }

        [Fact]
        public async Task Persons_Get_Specific()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());

            // Act
            var result = await controller.Get(16);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(16);
        }

        [Fact]
        public async Task Persons_Add()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());
            var newPerson = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 44,
                Title = "FooBar",
                Email = "john.doe@foo.bar"
            };

            // Act
            var result = await controller.Post(newPerson);

            // Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(51);
            Assert.Equal(51, person.Id);
            Assert.Equal("John", person.FirstName);
        }

        [Theory]
        [InlineData("John", "Doe", 44, "FooBar", "john.doe@foo.bar")]
        [InlineData("Ron", "Steve", 20, "FooBar", "ron.steve@foo.bar")]
        [InlineData("", "", 60, "FooBar", "john.doe@foo.bar")]
        public async Task Persons_Add_Test(String firstName, String lastName, int age, String title, String email)
        {
            // Arrange
            var controller = new PersonsController(new PersonService());
            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Title = title,
                Email = email          
                };

            // Act
            var result = await controller.Post(newPerson);

            // Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(51);
            Assert.Equal(51, person.Id);
        }
    }
}