﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.EF_DBContext_Repositories
{
    public interface IRepository
    {
       //List<T> GetAllEntries<T>();
       Boolean dbIsEmpty();
       Boolean deleteAllEntries();
    }
}
