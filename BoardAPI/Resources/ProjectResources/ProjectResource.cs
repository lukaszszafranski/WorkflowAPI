using System;
using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class ProjectResource
    {
        public string Title { get; set; }
        public IEnumerable<WorkItemResource> WorkItems { get; set; }
        public string Author { get; set; }
        public IEnumerable<TagResource> Tags { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public IEnumerable<ColumnResource> Columns { get; set; }
        public string VisibilityState { get; set; } //Private/Public
        public string Status { get; set; } //Archived, Closed, Done, etc.
    }
}
