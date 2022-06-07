using System.Collections.Generic;

namespace SystemView
{
    public class SpaceStation
    {
        public List<SystemShip>         LandedShips = new();
        public List<SystemShip>         OwnedShips  = new();

        public SystemViewBody           Self        = new();
        public OrbitingObjectDescriptor Descriptor;

        public SpaceStation()
        {
            Descriptor = new(Self);
        }
    }
}
