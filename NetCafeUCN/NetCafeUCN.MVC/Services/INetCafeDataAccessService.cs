﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.MVC.Services
{
    public interface INetCafeDataAccessService<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity? Get(dynamic key);
        public bool Add(TEntity o);
        public bool Remove(dynamic key);
        public bool Update(TEntity o);
    }
}