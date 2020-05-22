using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class ProjectResource
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public IEnumerable<ColumnResource> Columns { get; set; }
    }
}
