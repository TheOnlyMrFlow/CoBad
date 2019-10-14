using System;
using Cobad.CLI;
using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageMySQL.Adapters;

namespace Cobad.App
{
    class Program
    {
        static void Main(string[] args)
        {

            IFrontierePersistance frontierePersistance = new FrontiereStockageMySQL();

            var frontiereCobad = new FrontiereCobad(frontierePersistance);

            var parser = new CLIParser(frontiereCobad);

            parser.Parse(args);
        }
    }
}
