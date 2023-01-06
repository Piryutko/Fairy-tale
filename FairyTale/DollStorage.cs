using System.Collections.Generic;
using System.Linq;

namespace FairyTale
{
   public class DollStorage : IDollStorage
    {
        public DollStorage()
        {
            _dolls = new List<Doll>();
            _sugarDollFactory = new SugarDollFactory();
            _gingerbreadDollFactory = new GingerbreadDollFactory();
        }

        public void AddGingerbreadDolls(List<string> names)
        {
            foreach (var name in names)
            {
                var doll = _gingerbreadDollFactory.Create(name);
                _dolls.Add(doll);
            }
        }

        public void AddSugarDolls(List<string> names)
        {
            foreach (var name in names)
            {
                var doll = _sugarDollFactory.Create(name);
                _dolls.Add(doll);
            }
        }

        public bool ExistDoll(string name)
        {
            return _dolls.Any(d => d.Name == name);
        }

        public Doll GetDoll(string name)
        {
            var doll = GetAllDolls().First(d => d.Name == name);
            return doll;
        }

        public List<Doll> GetAllDolls() => _dolls;

        private readonly List<Doll> _dolls;

        private readonly GingerbreadDollFactory _gingerbreadDollFactory;

        private readonly SugarDollFactory _sugarDollFactory;
    }
}
