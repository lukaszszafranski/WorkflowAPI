using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class ProjectResource
    {
        public class ColumnResource
        {
            public string ColumnName { get; set; }
            public IEnumerable<TaskResource> Tasks { get; set; }
        }
    }
}
