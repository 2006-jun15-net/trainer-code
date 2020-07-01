using System.Collections.Generic;

namespace SimpleOrderApp.Domain
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();

        void Update(Location location);
    }
}