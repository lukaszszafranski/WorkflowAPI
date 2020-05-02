using BoardAPI.Models.ProjectsModels;
using BoardAPI.Models.UserModels;
using System.Collections.Generic;

namespace BoardAPI.Models.OrganizationsModels
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public IEnumerable<Project> ProjectsList { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}
