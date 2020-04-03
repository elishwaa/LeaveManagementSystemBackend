using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface IProjectService : IService
    {
      bool Add(ProjectAddRequest project);
      IEnumerable<Projects> Get();
    }
}
