using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    /// <summary>
    /// Denne klasse opretter en string som bliver brugt til at oprette forbindelse til databasen.
    /// </summary>
    public static class DBConnection
    {
        public static string ConnectionString
        {
            get { return "Data Source = hildur.ucn.dk; User ID = DMA-CSD-S212_10182474; Password = Password1!; Encrypt = False; TrustServerCertificate = True"; }
        }
    }
}
