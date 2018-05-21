﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierMailSR.Data
{
    public class ExpressDBContext : DbContext
    {
        public DbSet<ExpressReceiveInfo> ExpressReceiveInfos { get; set; }

        public DbSet<ExpressSendInfo> ExpressSendInfos { get; set; }


        public ExpressDBContext():base("name=ExpressDBContext")
        {

        }
    }
}
