using System.Collections.Generic;

namespace BoardAPI.Models.ProjectsModels
{
    public class Column
    {
        public int ColumnID { get; set; }
        public string ColumnName { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
