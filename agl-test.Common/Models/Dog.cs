namespace agl_test.Common.Models
{
    public class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age)
        {
        }

        public override void Introduce()
        {
            Console.WriteLine($"I am a dog, my name is {Name}");
        }
    }
}