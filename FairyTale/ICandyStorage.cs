using System.Collections.Generic;

namespace FairyTale
{
    public interface ICandyStorage
    {
        public void AddCandy(List<string> names);

        public List<Candy> GetAllCandies();

        public void DeleteAllCandies();
    }
}
