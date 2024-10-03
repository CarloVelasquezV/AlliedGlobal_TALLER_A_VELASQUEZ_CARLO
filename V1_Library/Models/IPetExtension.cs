
namespace V1_Library.Models
{
    public static class IPetExtension
    {
        public static List<IPet> SortPetsByName(this List<IPet> pets)
        {
            var result = new List<IPet>(pets);
            result.Sort((pet_a, pet_b) => pet_a.name.CompareTo(pet_b.name));
            return result;
        }
        public static List<IPet> SortPetsByPriceDesc(this List<IPet> pets)
        {
            var result = new List<IPet>(pets);
            return result.OrderByDescending(pet=>pet.price).ToList();
        }
        public static List<IPet> SortPetsByAge(this List<IPet> pets)
        {
            var result = new List<IPet>(pets);
            return result.OrderBy(pet=>pet.age).ToList();
        }
    }
}
