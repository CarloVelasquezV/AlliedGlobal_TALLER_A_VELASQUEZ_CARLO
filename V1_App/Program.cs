using V1_Library.Models;

namespace V1_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TALLER_A_VELASQUEZ_CARLO");
            List<IPet> pets = new List<IPet>();
            Random random = new Random();
            int petSpecie, petAge, petNumber;
            double petPrice;
            for (int i = 0; i < 10; i++)
            {
                petSpecie = random.Next(0, 2); //0-1(+1)
                petAge = random.Next(0, 101); //0-100(+1)
                petNumber = random.Next(1_000, 10_000); //1000-9999(+1)
                petPrice = random.NextDouble() * 100.0; //0-100
                switch (petSpecie)
                {
                    case 0:
                        pets.Add(new Dog(petAge, $"Dog #{petNumber}", petPrice)); break;
                    case 1:
                        pets.Add(new Cat(petAge, $"Cat #{petNumber}", petPrice)); break;
                }
            }

            #region 6. Ten IPet to have cats and dogs random
            Console.WriteLine("\n\n\n6. Ten IPet to have cats and dogs random");
            pets.ForEach(pet => Console.WriteLine($"{pet.name} | Age: {pet.age:D2} | ${pet.price:F2}"));
            #endregion

            #region 8. Sorted list of pets by descending price
            Console.WriteLine("\n\n\n8. Sorted list of pets by descending price");
            List<IPet> petsSortedPriceDesc = pets.SortPetsByPriceDesc();
            petsSortedPriceDesc.ForEach(pet => Console.WriteLine($"{pet.name} | Age: {pet.age:D2} | ${pet.price:F2}"));
            #endregion

            #region 9. Average Dog Price
            Console.WriteLine("\n\n\n9. Average Dog Price");
            Console.WriteLine($"Average Dog Price: ${pets.OfType<Dog>().Average(dog => dog.price):F2}");
            #endregion

            #region 10. Sorted list of only the cats by descending price
            Console.WriteLine("\n\n\n10. Sorted list of only the cats by descending price");
            List<IPet> petsSortedCatsPriceDesc = pets.SortPetsByPriceDesc().OfType<Cat>().ToList<IPet>();
            petsSortedCatsPriceDesc.ForEach(cat => Console.WriteLine($"{cat.name} | Age: {cat.age:D2} | ${cat.price:F2}"));
            #endregion

            #region 11. Sorted list of cats, now print only the odd elements
            Console.WriteLine("\n\n\n11. Sorted list of cats, now print only the odd elements");
            List<IPet> petsSortedCatsPriceDescOdds = pets.SortPetsByPriceDesc().OfType<Cat>().ToList<IPet>().Select((pet, index) => new { pet, index=index+1 }).Where(item => item.index % 2 == 0).Select(item => item.pet).ToList();
            petsSortedCatsPriceDescOdds.ForEach(cat => Console.WriteLine($"{cat.name} | Age: {cat.age:D2} | ${cat.price:F2}"));
            #endregion

            #region 12. PetPromotionList
            Console.WriteLine("\n\n\n12. PetPromotionList");
            List<IPet> PetPromotionList = new List<IPet>(
                pets.Select<IPet, IPet>(pet => 
                {
                    double newPrice = 0 < pet.age && pet.age < 5 ? 50.0 : pet.price;
                    newPrice = pet.age > 10 ? 0.0 : newPrice;
                    return pet switch
                    {
                        Dog dog => new Dog(dog.age, dog.name, newPrice),
                        Cat cat => new Cat(cat.age, cat.name, newPrice),
                        _ => throw new InvalidOperationException("IPet: Dog, Cat expected")
                    };
                }));
            PetPromotionList.ForEach(pet => Console.WriteLine($"{pet.name} | Age: {pet.age:D2} | ${pet.price:F2}"));
            #endregion

            //#region dev
            //Console.WriteLine("\n\n\nDev: original list");
            //pets.ForEach(pet => Console.WriteLine($"{pet.name} | Age: {pet.age:D2} | ${pet.price:F2}"));
            //#endregion
        }
    }
}
