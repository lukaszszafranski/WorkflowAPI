﻿/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2023
 */

using BoardAPI.Data;

namespace BoardAPI.Repositories.Persistence
{
    public abstract class BaseRepository
    {
        protected readonly WorkflowAPIContext _context;

        public BaseRepository(WorkflowAPIContext context)
        {
            _context = context;
        }
    }
}
