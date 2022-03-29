﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public void CreateBowler(Bowler b);
        public void Update(Bowler b);
        public void DeleteBowler(Bowler b);
        public void SaveChanges(Bowler b);
    }
}
