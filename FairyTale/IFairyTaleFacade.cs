using System.Collections.Generic;

namespace FairyTale
{
    public interface IFairyTaleFacade
    {
        public void AddCandies(List<string> names);

        public void AddGingerbreadDolls(List<string> names);

        public void AddSugarDolls(List<string> names);

        public void ExecuteMovementDoll(Doll doll);

        public List<Candy> GetAllCandies();

        public List<Doll> GetAllDolls();
    }
}
