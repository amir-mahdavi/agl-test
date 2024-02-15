using agl_test.Common.Models;
using agl_test.Common.Tools;

namespace agl_test.Tests
{
    public class AnimalSortingTests
    {
        [Fact]
        public void Animals_EmptyList_ShouldRemainEmpty()
        {
            // Arrange
            var animals = new List<Animal>();

            // Act
            var sortedByName = QuickSort.Sort(animals, a => a.Name);

            // Assert
            Assert.NotNull(sortedByName);
            Assert.Empty(sortedByName);
        }

        [Fact]
        public void Animals_SingleList_ShouldRemainSingle()
        {
            // Arrange
            var animals = new List<Animal>
            {
                new Cat("Catty", 3),
            };

            // Act
            var sortedByName = QuickSort.Sort(animals, a => a.Name);

            // Assert
            Assert.Single(sortedByName);
        }

        [Fact]
        public void Animals_EqualName_ShouldNotMove()
        {
            // Arrange
            var animals = new List<Animal>
            {
                new Cat("Catty", 3),
                new Cat("Catty", 5),
                new Dog("Doggo", 2)
            };

            // Act
            var sortedByName = QuickSort.Sort(animals, a => a.Name);

            // Assert
            Assert.Equal("Catty", sortedByName[0].Name);
            Assert.Equal(3, sortedByName[0].Age);
            Assert.Equal("Catty", sortedByName[1].Name);
            Assert.Equal(5, sortedByName[1].Age);
            Assert.Equal("Doggo", sortedByName[2].Name);
        }

        [Fact]
        public void Animals_SortedByName_ShouldBeInCorrectOrder()
        {
            // Arrange
            var animals = new List<Animal>
            {
                new Cat("Catty", 3),
                new Cat("Kitty", 5),
                new Dog("Doggo", 2)
            };

            // Act
            var sortedByName = QuickSort.Sort(animals, a => a.Name);

            // Assert
            Assert.Equal("Catty", sortedByName[0].Name);
            Assert.Equal("Doggo", sortedByName[1].Name);
            Assert.Equal("Kitty", sortedByName[2].Name);
        }

        [Fact]
        public void Animals_SortedByAge_ShouldBeInCorrectOrder()
        {
            // Arrange
            var animals = new List<Animal>
            {
                new Dog("Catty", 3),
                new Cat("Kitty", 5),
                new Dog("Doggo", 2)
            };

            // Act
            var sortedByAge = QuickSort.Sort(animals, a => a.Age);

            // Assert
            Assert.Equal(2, sortedByAge[0].Age);
            Assert.Equal(3, sortedByAge[1].Age);
            Assert.Equal(5, sortedByAge[2].Age);
        }
    }
}