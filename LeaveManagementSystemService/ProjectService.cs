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
        public bool Add(ProjectAddRequest project)
        {
            try
            {
                return _projectRepository.Add(project);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Projects> Get()
        {
            return _projectRepository.Get();
        }
    }
}
