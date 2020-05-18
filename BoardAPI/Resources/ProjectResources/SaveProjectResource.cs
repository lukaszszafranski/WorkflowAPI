using System;
using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class SaveProjectResource
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public IEnumerable<SaveColumnResource> Columns { get; set; }
    }
}
