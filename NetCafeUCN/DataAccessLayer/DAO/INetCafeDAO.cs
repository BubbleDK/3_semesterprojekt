using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    /* @authors Rasmus Gudiksen, Jakob Kjeldsteen, Emil Tolstrup Petersen, Christian Funder og Mark Drongesen
     * <summary>
     * Dette er et generic interface der beskriver metoderne i DAO.
     * <summary/>
     */
    public interface INetCafeDAO<TEntity>
    {
        /*
         * <summary>
	    * Metoden henter alle objekter af den angivet type.
	    * <summary/>
	    * <returns></returns>
	    */
        public IEnumerable<TEntity> GetAll();
        /*
        * <summary>
	    * Metoden henter et specifikt objekt af den angivet type.
	    * <summary/>
	    * <returns></returns>
	    */
        public TEntity? Get(dynamic key);
        /*
        * <summary>
	    * Metoden tilføjer et objekt af den angivet type.
	    * <summary/>
	    * <param name="o">Er argumentet i metoden</param>
	    * <returns>En bool</returns>
	    */
        public bool Add(TEntity o);
        /*
        * <summary>
	    * Metoden fjerner et specifikt objekt af den angivet type.
	    * <summary/>
	    * <param name="key">Er argumentet i metoden</param>
	    * <returns>En bool</returns>
	    */
        public bool Remove(dynamic key);
        /*
        * <summary>
	    * Metoden opdaterer et specifikt objekt af den angivet type.
	    * <summary/>
	    * <param name="o">Er argumentet i metoden</param>
	    * <returns>En bool</returns>
	    */
        public bool Update(TEntity o);
    }
}
