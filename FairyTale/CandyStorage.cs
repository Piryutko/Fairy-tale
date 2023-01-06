using System.Collections.Generic;

namespace FairyTale
{
    public class CandyStorage : ICandyStorage
    {
        public CandyStorage()
        {
            _candies = new List<Candy>();
        }

        public void AddCandy(List<string> names)
        {
            foreach (var name in names)
            {
                _candies.Add(new Candy(name));
            }
        }

        public List<Candy> GetAllCandies() => _candies;

        public void DeleteAllCandies() => _candies.Clear();

        private readonly List<Candy> _candies;

    }
}
