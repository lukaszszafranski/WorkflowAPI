using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class SaveProjectResource
    {
        public class SaveColumnResource
        {
            public string ColumnName { get; set; }
            public IEnumerable<SaveTaskResource> Tasks { get; set; }
        }
    }
}
