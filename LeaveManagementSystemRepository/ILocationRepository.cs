using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface ILocationRepository : IRepository
    {
        bool Add(LocationAddRequest location);
        IEnumerable<Locations> Get();
    }
}
