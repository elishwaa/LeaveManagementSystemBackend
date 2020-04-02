using LeaveManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemRepository
{
    public interface IProjectRepository : IRepository
    {
        bool NewProject(NewProject newProject);
        IEnumerable<Projects> GetProject();
    }
}
