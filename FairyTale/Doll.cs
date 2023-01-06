using EnsureThat;

namespace FairyTale
{
    public class Doll
    {
        public Doll(string name)
        {
            Ensure.That(name).IsNotNullOrWhiteSpace();
            Name = name;
            Movement = MovementType.Stand;
            Location = LocationType.Wardrobe;
        }

        public string Name { get; }

        public MovementType Movement { get; private set; }

        public LocationType Location { get; private set; }

        public void ExecuteMovement(MovementType movementType) => Movement = movementType;

        public void ChangeLocation(LocationType locationType) => Location = locationType;

    }
}
