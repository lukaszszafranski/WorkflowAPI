/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using System.Collections.Generic;

namespace BoardAPI.Models.ProjectsModels
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public IEnumerable<Column> Columns { get; set; }
        public IEnumerable<Timesheet> Timesheets { get; set; }
    }
}
