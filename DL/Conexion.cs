﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConexion()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["UEstebanPruebaPasiente"].ConnectionString;
        }
    }
}
