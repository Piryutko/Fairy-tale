using System.Collections.Generic;

namespace FairyTale
{
    public interface IDollStorage
    {
        public void AddGingerbreadDolls(List<string> names);

        public void AddSugarDolls(List<string> names);

        public bool ExistDoll(string name);

        public Doll GetDoll(string name);

        public List<Doll> GetAllDolls();

    }
}
