using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardAPI.Models.ProjectsModels
{
    public class Column
    {
        public int ColumnID { get; set; }
        public string ColumnName { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

        //Foreign Keys
        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
    }
}
