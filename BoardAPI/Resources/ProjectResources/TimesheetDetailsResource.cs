/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

namespace BoardAPI.Resources
{
    public class TimesheetDetailsResource
    {
        public int TimesheetDetailsID { get; set; }
        public int? Day { get; set; }
        public double? RegisteredHours { get; set; }
        public int? TimesheetID { get; set; }
        public string? ProjectTitle { get; set; }
    }
}