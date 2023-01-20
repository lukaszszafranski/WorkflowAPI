/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

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
