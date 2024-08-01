using GetGreeting;
using Moq;
using NUnit.Framework;



namespace GetGreeting.Tests
{
    public class GetGreetingProviderTests
    {
        private GreetingProvider _greetingProvider;
        private Mock<ITimeProvider> _mockedTimeProvider;

        [SetUp]
        public void Setup()
        {
            _mockedTimeProvider = new Mock<ITimeProvider> ();
            _greetingProvider = new GreetingProvider(_mockedTimeProvider.Object);
        }

        [Test]
        public void GetGreeting_ShouldReturnMorningMessage_WhenItIsMorning()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 9, 9, 9));

            var result = _greetingProvider.GetGreeting();

            Assert.That(result, Is.EqualTo("Good morning!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnAfternoonMessage_WhenItIsAfternoon()
        {
            //Arrange
           _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 12, 12, 12));
            
            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo("Good afternoon!"));
        }
        [Test]
        public void GetGreeting_ShouldReturnEveningMessage_WhenItIsEvening()
        {    
            //Arrange
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 3, 3, 19, 19, 19));

            //Act
            var result = _greetingProvider.GetGreeting();

            //Assert
            Assert.That(result, Is.EqualTo("Good evening!"));
        }
        [Test]
        public void GetGreeting_ShouldReturnNightMessage_WhenItIsNight()
        {
            //Arrange
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 4, 4, 21, 21, 21));
            //Act
            var result = _greetingProvider.GetGreeting();
            //Assert
            Assert.That(result, Is.EqualTo("Good nght!"));

        }
    }
}