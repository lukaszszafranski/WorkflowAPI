/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using BoardAPI.Data;
using BoardAPI.Repositories.Domain;
using System.Threading.Tasks;

namespace BoardAPI.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkflowAPIContext _context;

        public UnitOfWork(WorkflowAPIContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
