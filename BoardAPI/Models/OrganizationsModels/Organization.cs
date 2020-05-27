/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

namespace BoardAPI.Models.OrganizationsModels
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        //public IEnumerable<Project> ProjectsList { get; set; }

        //// Foreign Keys
        //public IEnumerable<User> Members { get; set; }
    }
}
