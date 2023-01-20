/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public partial class ProjectResource
    {
        public class ColumnResource
        {
            public int ColumnID { get; set; }
            public string ColumnName { get; set; }
            public IEnumerable<TaskResource> Tasks { get; set; }
        }
    }
}
