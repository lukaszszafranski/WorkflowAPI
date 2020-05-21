using System.ComponentModel.DataAnnotations.Schema;

namespace BoardAPI.Models.ProjectsModels
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }

        //Foreign Keys
        public Column Column { get; set; }
        [ForeignKey("Column")]
        public int ColumnID { get; set; }
    }
}
