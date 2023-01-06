using EnsureThat;
using System.Collections.Generic;

namespace FairyTale
{
    public class CandyFacade : ICandyFacade
    {
        public CandyFacade(ICandyStorage candiesStorage)
        {
            Ensure.That(candiesStorage).IsNotNull();
            _candiesStorage = candiesStorage;
        }

        private readonly ICandyStorage _candiesStorage;

        public void Add(List<string> names) => _candiesStorage.AddCandy(names);

        public List<Candy> GetAllCandies() => _candiesStorage.GetAllCandies();

        public void DeleteAll() => _candiesStorage.DeleteAllCandies();
    }
}
