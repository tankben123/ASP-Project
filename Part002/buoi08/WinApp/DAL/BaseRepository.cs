﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class BaseRepository
    {
        public BookStoreContext context;
        public BaseRepository(BookStoreContext context)
        {
            this.context = context;
        }
    }
}
