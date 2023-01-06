using System.Collections.Generic;

namespace FairyTale
{
    public class RatKing
    {
        public RatKing()
        {
            Hungry = true;
            EatenSweetsCount = 0;
        }

        public MovementType Movement { get; private set; }

        public LocationType Location { get; private set; }

        public bool Hungry { get; private set; }

        public int EatenSweetsCount { get; private set; }

        public delegate void RatKingWhistlingHandler (MovementType movement);

        public event RatKingWhistlingHandler NotifyGoodMarie;

        public delegate void RatKingGnawNutcrackerHandler();

        public event RatKingGnawNutcrackerHandler GnawNutcracker;

        public void ExecuteMovement(MovementType movement)
        {
            if (movement == MovementType.Whistling)
            {
                NotifyGoodMarie(MovementType.Hear);
            }

            Movement = movement;
        }

        public void ChangeLocation(LocationType location) => Location = location;

        public void EatCandies(List<Candy> candies)
        {
            foreach (var candy in candies)
            {
                if (candy.Name != NOT_FAVORITE_CANDY)
                {
                    EatenSweetsCount++;
                }
            }

            Hungry = false;
        }

        public void Gnaw(object character)
        {
            if (character.GetType() == typeof(Nutcracker))
            {
                GnawNutcracker();
            }
        }

        private const string NOT_FAVORITE_CANDY = "Marzipan";
    }
}
