using Cobad.Domaine.PortsSecondaires.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.StockageMySQL.Adapters
{
    public class FrontiereStockageMySQL : IFrontierePersistance
    {
        public FrontiereStockageMySQL()
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
        }

        public IRepertoireClubs RepertoireClubs => throw new NotImplementedException();

        public IRepertoireCollectifs RepertoireCollectifs => throw new NotImplementedException();

        public IRepertoireJoueurs RepertoireJoueurs => throw new NotImplementedException();
    }


}
