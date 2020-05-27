/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using System.Collections.Generic;

namespace BoardAPI.Resources
{
    public class SaveOrganizationResource
    {
        public string OrganizationName { get; set; }
        public IEnumerable<ProjectResource> ProjectsList { get; set; }
    }
}
