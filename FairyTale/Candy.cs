using EnsureThat;

namespace FairyTale
{
    public class Candy
    {
        public Candy(string name)
        {
            Ensure.That(name).IsNotEmptyOrWhiteSpace();
            Name = name;
        }

        public string Name { get; }
    }
}
