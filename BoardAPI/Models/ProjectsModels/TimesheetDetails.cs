﻿/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BoardAPI.Models.ProjectsModels
{
    public class TimesheetDetails
    {
        public int TimesheetDetailsID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int RegisteredHours { get; set; }

        //Foreign Keys
        public Timesheet Timesheet { get; set; }
        [ForeignKey("Timesheet")]
        public int TimesheetID { get; set; }
    }
}