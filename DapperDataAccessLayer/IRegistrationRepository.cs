﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public interface IRegistrationRepository
    {
        public void Insert(Registration reg);
        public Registration FindByNumber(long number);
        public IEnumerable<Registration> GetRegistrations();
       
        public bool Login(String name, string password);

    }
}
