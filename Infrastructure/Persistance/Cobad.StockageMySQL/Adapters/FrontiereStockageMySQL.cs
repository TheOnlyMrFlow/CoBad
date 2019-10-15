using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.Adapters
{
    public class FrontiereStockageMySQL : IFrontierePersistance
    {
        public FrontiereStockageMySQL(string connectionString)
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
            DBConnection.SetConnectionString(connectionString);

            this.RepertoireClubs = new RepertoireClubs();
            this.RepertoireCollectifs = new RepertoireCollectifs();
            this.RepertoireJoueurs = new RepertoireJoueurs();
        }

        public IRepertoireClubs RepertoireClubs { get; private set; }

        public IRepertoireCollectifs RepertoireCollectifs { get; private set; }

        public IRepertoireJoueurs RepertoireJoueurs { get; private set; }
    }


}
