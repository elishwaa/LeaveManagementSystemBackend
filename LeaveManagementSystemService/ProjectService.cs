using LeaveManagementSystemModels;
using LeaveManagementSystemRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystemService
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public bool NewProject(NewProject newProject)
        {
            return _projectRepository.NewProject(newProject);
        }

        public IEnumerable<Projects> GetProject()
        {
            return _projectRepository.GetProject();
        }
    }
}
