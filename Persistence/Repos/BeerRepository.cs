﻿using Domain;

namespace Persistence.Repos
{
    public class BeerRepository : Repository<Beer>, IBeerRepository
    {
        private DataContext _context;

        public BeerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}