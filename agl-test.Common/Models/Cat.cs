namespace agl_test.Common.Models
{
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public override void Introduce()
        {
            Console.WriteLine($"I am a cat, my name is {Name}");
        }
    }
}