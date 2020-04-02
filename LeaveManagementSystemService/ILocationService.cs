using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface ILocationService : IService
    {
        bool NewLocation(NewLocation newLocation);
        IEnumerable<Locations> GetLocations();
    }
}
