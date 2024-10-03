﻿
namespace V1_Library.Models
{
    public class Dog : IPet
    {
        public int age {  get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public Dog(int age, string name, double price)
        {
            this.age = age;
            this.name = name;
            this.price = price;
        }
        public string makeAnimalSound(int volume)
        {
            string sound = $"bark volume: {volume}";
            Console.WriteLine(sound);
            return sound;
        }
    }
}
