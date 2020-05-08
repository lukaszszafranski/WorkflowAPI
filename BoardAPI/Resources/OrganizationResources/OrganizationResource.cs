using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public class OrganizationResource
    {
        public string OrganizationName { get; set; }
        public IEnumerable<ProjectResource> ProjectsList { get; set; }
    }
}
