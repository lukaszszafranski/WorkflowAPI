/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

namespace BoardAPI.Models.ProjectsModels
{
    public class UpdateProject
    {
        public string Title { get; set; }
        public string VisibilityState { get; set; } //Private/Public
        public string Status { get; set; } //Archived, Closed, Done, etc.
    }
}
