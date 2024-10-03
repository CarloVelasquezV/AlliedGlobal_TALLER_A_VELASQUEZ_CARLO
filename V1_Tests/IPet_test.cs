using V1_Library.Models;

namespace V1_Tests
{
    [TestClass]
    public class IPet_test
    {
        private List<IPet> pets = new List<IPet>()
        {
            new Dog(86, "Dog #6494", 52.12),
            new Cat(25, "Cat #5441", 25.77),
            new Cat(96, "Cat #4664", 69.45),
            new Cat(39, "Cat #6331", 84.97),
            new Cat(53, "Cat #7740", 16.52),
            new Dog(95, "Dog #6502", 17.84),
            new Cat(79, "Cat #4925", 28.07),
            new Dog(86, "Dog #2932", 81.68),
            new Dog(22, "Dog #9618", 37.94),
            new Dog(17, "Dog #9088", 88.67)
        };
        [TestMethod]
        public void A001_makeAnimalSound()
        {
            Random random = new Random();
            int volume;
            string petAnimalSound, expectedAnimalSound;
            foreach (var pet in pets)
            {
                volume = random.Next(0, 100);
                petAnimalSound = pet.makeAnimalSound(volume);
                expectedAnimalSound = pet switch
                {
                    Dog dog => $"bark volume: {volume}",
                    Cat cat => $"meow volume: {volume}"
                };
                Assert.AreEqual(petAnimalSound, expectedAnimalSound);
            }
        }
    }
}