/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using System;
using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public class ManagerTimesheetResource
    {
        public int TimesheetID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string TimesheetStatus { get; set; }
        public IEnumerable<TimesheetDetailsResource>? TimesheetDetails { get; set; }
        public string userId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? role { get; set; }
    }
}
