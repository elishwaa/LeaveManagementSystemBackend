using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public interface IProjectService : IService
    {
      bool NewProject(NewProject newProject);
      IEnumerable<Projects> GetProject();
    }
}
