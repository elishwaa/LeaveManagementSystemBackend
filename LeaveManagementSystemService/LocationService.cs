using LeaveManagementSystemModels;
using LeaveManagementSystemRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Locations> GetLocations()
        {
            return _locationRepository.GetLocations();
        }

        public bool NewLocation(NewLocation newLocation)
        {
           return  _locationRepository.NewLocation(newLocation);
        }
    }
}
