using System;
using System.IO;
using AccesseurPoonaCSV;
using Cobad.CLI;
using Cobad.Domaine;
using Cobad.Domaine.PortsSecondaires.Persistence;
using Cobad.StockageMySQL.Adapters;
using Microsoft.Extensions.Configuration;


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

            var connectionString = configuration.GetSection("Secrets")["MySQLConnectionString"];
            var frontierePersistance = new FrontiereStockageMySQL(connectionString);

            var accesseurPoona = new AccesseurPoonaParFichierCSV();

            var frontiereCobad = new FrontiereCobad(frontierePersistance, accesseurPoona);

            var parser = new CLIParser(frontiereCobad);

            parser.Parse(args);
        }
    }
}
