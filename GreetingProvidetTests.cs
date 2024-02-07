using GetGreeting;
using Moq;

namespace GetGreeting.Tests
{
    public class GreetingProviderTests
    {
        private GreetingProvider _greetingProvider;
        private Mock<iTimeProvider> _mockTimeProvider;

        [SetUp]
        public void SetUp()
        {
            _mockTimeProvider = new Mock<iTimeProvider>();
            _greetingProvider = new GreetingProvider(_mockTimeProvider.Object);
        }

        [Test]
        public void GetGreeting_ShouldReturnAMorningMesage_WhenIsMorning()
        {
            // Arange
            _mockTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2024, 02, 7, 11, 30, 25));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.AreEqual("Good morning!", result);
        }

        [Test]
        public void GetGreeting_ShouldReturnAAfternoonMesage_WhenIsAfternoon()
        {
            // Arange
            _mockTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 02, 07, 13, 03, 22));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.That(result, Is.EqualTo("Good afternoon!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnAEveningMesage_WhenIsEvening()
        {
            // Arange
            _mockTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 02, 07, 19, 03, 22));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.That(result, Is.EqualTo("Good evening!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnANightMesage_WhenIsNight()
        {
            // Arange
            _mockTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 02, 07, 23, 03, 22));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.That(result, Is.EqualTo("Good night!"));
        }

        [TestCase("Good morning!", 11)]
        [TestCase("Good afternoon!", 13)]
        [TestCase("Good evening!", 19)]
        [TestCase("Good night!", 23)]
        public void GetGreeting_ShouldReturnANightMesage_WhenIsNight(string expectedMessage, int currentHour)
        {
            // Arange
            _mockTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 02, 07, currentHour, 03, 22));

            // Act
            var result = _greetingProvider.GetGreeting();

            // Assert
            Assert.That(result, Is.EqualTo(expectedMessage));
        }
    }
}