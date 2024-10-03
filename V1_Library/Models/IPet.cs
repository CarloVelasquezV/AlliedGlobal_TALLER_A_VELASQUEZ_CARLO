
namespace V1_Library.Models
{
    public interface IPet
    {
        int age { get; set; }
        string name { get; set; }
        double price { get; set; }
        public string makeAnimalSound(int volume);
    }
}
