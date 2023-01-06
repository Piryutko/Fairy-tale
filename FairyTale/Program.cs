using System;
using System.Collections.Generic;

namespace FairyTale
{
    class Program
    {
        static public List<string> GetSugarDollNames()
        {
            return new List<string>() { "Shepherd", "Shepherd Boy", "Lamb", "Lamb", "Lamb", "Dog", "Postman", "Postman" };
        }

        static public List<string> GetGingerbreadDollNames()
        {
            return new List<string>() { "Boy", "Girl", "Boy", "Girl", "Boy", "Girl", "Boy", "Girl", "Pachter Feldkummel", "Maid of Orleans", "Red-Cheeked baby" };
        }

        static public List<string> GetCandyNames()
        {
            return new List<string>() { "Chocolate", "Sugar", "Gingerbread", "Toffee", "Marzipan" };
        }

        static void Main(string[] args)
        {
            var clock = new Clock(new DateTime(1816, 12, 12, 23, 12, 10));

            var dollStorage = new DollStorage();
            var candyStorage = new CandyStorage();

            var candyFacade = new CandyFacade(candyStorage); 
            var fairyTaleFacade = new FairyTaleFacade(dollStorage, candyFacade);

            fairyTaleFacade.AddCandies(GetCandyNames());
            fairyTaleFacade.AddSugarDolls(GetSugarDollNames());
            fairyTaleFacade.AddGingerbreadDolls(GetGingerbreadDollNames());

            var goodMarie = new GoodMarie(dollStorage.GetAllDolls(), candyStorage.GetAllCandies());
            var nutcracker = new Nutcracker();
            var ratKing = new RatKing();

            ratKing.NotifyGoodMarie += goodMarie.ExecuteMovement;
            ratKing.GnawNutcracker += nutcracker.Die;

            //Beginning of the fairy tale

            ratKing.EatCandies(goodMarie.GiveAllCandies());

            if (nutcracker.Live)
            {
                goodMarie.ChangeSoulMood(SoulMoodType.Happy);
            }
            else
            {
                goodMarie.ChangeSoulMood(SoulMoodType.Upset);
                throw new Exception("The nutcracker didn't survive");
            }

            clock.AddDay();

            ratKing.ExecuteMovement(MovementType.Whistling);
            if (goodMarie.Movement != MovementType.Hear)
            { 
                throw new Exception("Good Marie didn't hear rat king");
            }

            ratKing.ExecuteMovement(MovementType.SitDown);
            ratKing.ChangeLocation(LocationType.Table);
            ratKing.ExecuteMovement(MovementType.FlashingEyes);
            ratKing.ExecuteMovement(MovementType.Whistling);

            //According to the plot of the fairy tale, Marie will try to give away the dolls
            if (goodMarie.CanGiveAllDolls(ratKing))
            {
                ratKing.ExecuteMovement(MovementType.Hiding);
                ratKing.ChangeLocation(LocationType.Floor);

                goodMarie.ChangeSoulMood(SoulMoodType.Upset);

                clock.AddDay();

                goodMarie.ChangeLocation(LocationType.Wardrobe);
                goodMarie.ExecuteMovement(MovementType.See);

                foreach (var doll in goodMarie.ShowAllDolls())
                {
                    if (goodMarie.DontReallyLike(doll.Name))
                    {
                        Console.WriteLine($"Mary Dont Really Like: {doll.Name}");
                        continue;
                    }

                    if (goodMarie.ReallyLike(doll.Name))
                    {
                        doll.ChangeLocation(LocationType.Cradle);
                        Console.WriteLine($"Mary Really Like: {doll.Name} in {doll.Location}");
                        continue;
                    }

                    fairyTaleFacade.ExecuteMovementDoll(doll);
                    Console.WriteLine($"{doll.Name} | {doll.Movement}");
                }
            }
            else
            {
                ratKing.Gnaw(nutcracker);
                if (nutcracker.Live != false)
                {
                    throw new Exception("Nutcracker is alive");
                }
            }
        }
    }
}

