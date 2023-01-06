using EnsureThat;

namespace FairyTale
{
    public class SugarDollFactory : DollFactory
    {
        public override Doll Create(string name)
        {
            Ensure.That(name).IsNotEmptyOrWhiteSpace();
            return new SugarDoll(name);
        }
    }
}
