using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface ILocationService : IService
    {
        bool Add(LocationAddRequest location);
        IEnumerable<Locations> Get();
    }
}
