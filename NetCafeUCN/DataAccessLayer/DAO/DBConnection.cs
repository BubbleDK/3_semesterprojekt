﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    public static class DBConnection
    {
        public static string ConnectionString
        {
            get { return ConnectionString; }
            set { ConnectionString = @"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S212_10182474;Password=Password1!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; }
        }
    }
}