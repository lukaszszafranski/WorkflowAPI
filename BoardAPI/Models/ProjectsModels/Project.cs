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
        public IEnumerable<Column> Columns { get; set; }
    }
}
