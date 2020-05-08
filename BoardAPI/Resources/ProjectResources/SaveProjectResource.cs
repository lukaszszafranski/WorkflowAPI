using System;
using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class SaveProjectResource
    {
        public string Title { get; set; }
        public IEnumerable<SaveWorkItemResource> WorkItems { get; set; }
        public string Author { get; set; }
        public IEnumerable<SaveTagResource> Tags { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public IEnumerable<SaveColumnResource> Columns { get; set; }
        public string VisibilityState { get; set; } //Private/Public
        public string Status { get; set; } //Archived, Closed, Done, etc.
    }
}
