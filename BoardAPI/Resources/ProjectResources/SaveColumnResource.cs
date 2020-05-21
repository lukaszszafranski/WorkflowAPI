using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class SaveProjectResource
    {
        public class SaveColumnResource
        {
            public int ColumnID { get; set; }
            public string ColumnName { get; set; }
            public IEnumerable<SaveTaskResource> Tasks { get; set; }
        }
    }
}
