using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FairyTale
{
   public class FairyTaleFacade : IFairyTaleFacade
    {
        public FairyTaleFacade(IDollStorage dollsStorage, ICandyFacade candyFacade)
        {
            Ensure.That(dollsStorage).IsNotNull();
            Ensure.That(candyFacade).IsNotNull();

            _dollsStorage = dollsStorage;
            _candyFacade = candyFacade;

            _dollsMovements = new Dictionary<string, MovementType>
                {{ "Shepherd", MovementType.Herding},
                { "Shepherd Boy", MovementType.Herding},
                { "Lamb", MovementType.Frolicking},
                { "Pachter Feldkummel", MovementType.Stand},
                { "Maid of Orleans", MovementType.Stand },
                { "Red-Cheeked baby", MovementType.Lies },
                { "Postman", MovementType.Stand },
                { "Dog", MovementType.Jump },
                { "Boy", MovementType.Dance },
                { "Girl", MovementType.Dance} };
        }

        public void AddCandies(List<string> names) => _candyFacade.Add(names);

        public void AddGingerbreadDolls(List<string> names) => _dollsStorage.AddGingerbreadDolls(names);

        public void AddSugarDolls(List<string> names) => _dollsStorage.AddSugarDolls(names);

        public void ExecuteMovementDoll(Doll doll)
        {
            try
            {
                var movement = _dollsMovements.Single(m => m.Key == doll.Name).Value;
                doll.ExecuteMovement(movement);
            }
            catch (Exception)
            {
            }
        }

        public List<Candy> GetAllCandies() => _candyFacade.GetAllCandies();

        public List<Doll> GetAllDolls() => _dollsStorage.GetAllDolls();

        private readonly IDollStorage _dollsStorage;
        private readonly ICandyFacade _candyFacade;

        private readonly Dictionary<string, MovementType> _dollsMovements;

    }
}
