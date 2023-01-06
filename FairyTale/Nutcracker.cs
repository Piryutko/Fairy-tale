namespace FairyTale
{
   public class Nutcracker
    {
        public Nutcracker()
        {
            Live = true;
        }

        public bool Live { get; private set; }

        public void Die() => Live = false;

    }
}
