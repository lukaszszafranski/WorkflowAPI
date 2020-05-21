using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class ProjectResource
    {
        public class ColumnResource
        {
            public int ColumnID { get; set; }
            public string ColumnName { get; set; }
            public IEnumerable<TaskResource> Tasks { get; set; }
        }
    }
}
