/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BoardAPI.Models.UserModels
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Foreign Keys
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
