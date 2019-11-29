using System;
using System.IO;
using AccesseurPoonaCSV;
using Cobad.CLI;
using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageMySQL.Adapters;
using Cobad.StockageSQLite.Adapters;
using Microsoft.Extensions.Configuration;
using ImportCompetitionXML;


namespace Cobad.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            //var connectionString = configuration.GetSection("Secrets")["MySQLConnectionString"];

            var frontierePersistance = new FrontiereStockageSQLite();

            var accesseurPoona = new AccesseurPoonaParFichierCSV();

            var importeurCompetition = new ImporteurDeCompetitionParFichierXML(frontierePersistance); ;

            var frontiereCobad = new FrontiereCobad(frontierePersistance, accesseurPoona, importeurCompetition);

            var parser = new CLIParser(frontiereCobad);

            parser.Parse(args);
        }
    }
}
