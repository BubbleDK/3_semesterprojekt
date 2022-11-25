using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    /* @authors Rasmus Gudiksen, Jakob Kjeldsteen, Emil Tolstrup Petersen, Christian Funder og Mark Drongesen
     * <summary>
     * Denne klasse opretter en string som bliver brugt til at oprette forbindelse til databasen.
     * <summary/>
     */
    public static class DBConnection
    {
        /*
         * * <summary>
         * Metoden laver en string 
         * <summary/>
         * <returns>En string<returns/>
         */
        public static string ConnectionString
        {
            get { return "Data Source = hildur.ucn.dk; User ID = DMA-CSD-S212_10182474; Password = Password1!; Encrypt = False; TrustServerCertificate = True"; }
        }
    }
}
