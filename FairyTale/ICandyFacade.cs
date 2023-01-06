using System.Collections.Generic;

namespace FairyTale
{
    public interface ICandyFacade
    {
        public void Add(List<string> names);

        public List<Candy> GetAllCandies();

        public void DeleteAll();
    }
}
