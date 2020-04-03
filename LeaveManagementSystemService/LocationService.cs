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

        public IEnumerable<Locations> Get()
        {
            try
            {
                return _locationRepository.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(LocationAddRequest location)
        {
            try
            {
                return _locationRepository.Add(location);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
