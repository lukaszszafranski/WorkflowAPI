using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Models.UserModels;
using System;
using System.Collections.Generic;

namespace BoardAPI.Models.ProjectsModels
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public IEnumerable<WorkItem> WorkItems { get; set; }
        public string Author { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public IEnumerable<Column> Columns { get; set; }
        public string VisibilityState { get; set; } //Private/Public
        public string Status { get; set; } //Archived, Closed, Done, etc.

        // Foreign Keys
        
        // Organization
        public int OrganizationID { get; set; } //null if not in any organization
        public Organization Organization { get; set; }

        // User
        public IEnumerable<User> Members { get; set; }
    }
}
