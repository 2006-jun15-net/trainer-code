using System.Collections.Generic;

namespace SimpleOrderApp.Domain
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();

        void Create(Location location);

        void Update(Location location);
    }
}