using ToDoManager.TelegramBot.DataAccess.Fake;
using Xunit;

namespace FakeDataTests
{
    public class FakeToDoItemRepositoryTests
    {
        [Fact]
        public void Add_ShouldAddNewValue()
        {
            // arrange
            var id = Guid.NewGuid();
            var userId = "userId";
            var name = "name";
            var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
            var priority = true;
            var status = true;

            var expectedToDoItem = new ToDoItem(
                id,
                userId,
                name,
                deadLine,
                priority,
                status);

            var fakeToDoItemRepository = new FakeToDoItemRepository();

            // act
            fakeToDoItemRepository.Add(expectedToDoItem);
            var actualToDoItem = fakeToDoItemRepository.Get(id);

            // assert
            Assert.Equal(expectedToDoItem, actualToDoItem);
        }

        [Fact]
        public void Get_ShouldReturnValue()
        {
            // arrange
            var id = Guid.NewGuid();
            var userId = "userId";
            var name = "name";
            var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
            var priority = true;
            var status = true;

            var expectedToDoItem = new ToDoItem(
                id,
                userId,
                name,
                deadLine,
                priority,
                status);

            var fakeToDoItemRepository = new FakeToDoItemRepository();
            fakeToDoItemRepository.Add(expectedToDoItem);

            // act
            var actualToDoItem = fakeToDoItemRepository.Get(id);

            // assert
            Assert.Equal(expectedToDoItem, actualToDoItem);
        }

        [Fact]
        public void Delele_ShouldDeleteValue_ReturnNull()
        {
            // arrange
            var id = Guid.NewGuid();
            var userId = "userId";
            var name = "name";
            var deadLine = DateTime.UtcNow.Add(TimeSpan.FromHours(1));
            var priority = true;
            var status = true;

            var toDoItem = new ToDoItem(
                id,
                userId,
                name,
                deadLine,
                priority,
                status);

            var fakeToDoItemRepository = new FakeToDoItemRepository();
            fakeToDoItemRepository.Add(toDoItem);

            // act
            fakeToDoItemRepository.Delete(id);

            // assert
            Assert.Null(fakeToDoItemRepository.Get(id));
        }
    }
}