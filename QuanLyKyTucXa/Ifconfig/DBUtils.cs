﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace ketnoicsdllan1
{
    internal class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"Vo_Van_Chinh\SQLEXPRESS";
            string database = "QuanLyKTX";
            string username = "sa";
            string password = "chinh@2003";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}