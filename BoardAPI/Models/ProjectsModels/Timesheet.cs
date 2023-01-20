/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using BoardAPI.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardAPI.Models.ProjectsModels
{
    public class Timesheet
    {
        public int TimesheetID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string TimesheetStatus { get; set; }
        public IEnumerable<TimesheetDetails>? TimesheetDetails { get; set; }

        //Foreign Keys
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
