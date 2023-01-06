using EnsureThat;

namespace FairyTale
{
    public class GingerbreadDollFactory : DollFactory
    {
        public override Doll Create(string name)
        {
            Ensure.That(name).IsNotEmptyOrWhiteSpace();
            return new GingerbreadDoll(name);
        }
    }
}
