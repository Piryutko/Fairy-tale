using EnsureThat;
using System.Collections.Generic;
using System.Linq;

namespace FairyTale
{
    public class GoodMarie
    {
        public GoodMarie(List<Doll> dolls, List<Candy> candies)
        {
            Ensure.That(dolls).IsNotNull();
            Ensure.That(dolls).HasItems();
            Ensure.That(candies).IsNotNull();
            Ensure.That(candies).HasItems();

            _dolls = dolls;
            Candies = candies;
            SoulMood = SoulMoodType.Happy;
        }

        public List<Candy> Candies { get; private set; }

        public SoulMoodType SoulMood { get; private set; }

        public LocationType Location { get; private set; }

        public MovementType Movement { get; private set; }

        public void ChangeSoulMood(SoulMoodType newSoulMood) => SoulMood = newSoulMood;

        public void ChangeLocation(LocationType newLocation) => Location = newLocation;

        public bool DontReallyLike(string dollName)
        {
            if (_dontReallyLikeDollNames.Any(n => n == dollName))
            {
                ChangeSoulMood(SoulMoodType.Upset);
                return true;
            }

            return false;
        }

        public bool ReallyLike(string dollName)
        {
            if (_reallyLikeDollNames.Any(n => n == dollName))
            {
                ChangeSoulMood(SoulMoodType.Happy);
                return true;
            }

            return false;

        }

        public bool CanGiveAllDolls(object character)
        {
            if (character.GetType() == typeof(RatKing))
            {
                return true;
            }

            return false;
        }

        public List<Candy> GiveAllCandies()
        {
            var candies = new List<Candy>();

            foreach (var candy in Candies)
            {
                candies.Add(candy);
            }

            Candies.Clear();

            return candies;
        }

        public List<Doll> ShowAllDolls() => _dolls;

        public void ExecuteMovement(MovementType newMovementType) => Movement = newMovementType;

        private readonly List<string> _dontReallyLikeDollNames = new() { "Pachter Feldkummel", "Maid of Orleans" };

        private readonly List<string> _reallyLikeDollNames = new() { "Red-Cheeked baby" };

        private List<Doll> _dolls;
    }
}
