//using System;
//using Xunit;
//using Cobad.StockageSQLite.Adapters;
//using FluentAssertions;
//using Cobad.Domaine;
//using System.Collections.Generic;

//namespace Cobad.StockageSQLite.Test
//{
//    public class TestCompetition : IDisposable
//    {

//        public FrontiereStockageSQLite StockageSQLite;

//        public string dbFilePath;

//        public TestCompetition()
//        {


//            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
//            var cobadFolder = System.IO.Path.Combine(appDataFolder, "Cobad");
//            dbFilePath = System.IO.Path.Combine(cobadFolder, "cobad-test.db");

//            if (!System.IO.File.Exists(dbFilePath))
//            {
//                System.IO.Directory.CreateDirectory(cobadFolder);
//                System.IO.File.Create(dbFilePath).Close();
//            }

//            StockageSQLite = new FrontiereStockageSQLite("cobad-test.db");

//            var competition = new Competition
//            {
//                Nom = "compet 123",
//                Date = new DateTime(2019, 2, 4),
//                Tableaux = new List<Tableau>
//                {
//                   new Tableau {
//                        Id = 1,
//                        Nom = "tableau 1",
//                        Categorie = "Hommes simple",
//                        Niveau = "Regional",
//                        Rounds = new List<Round>()
//                        {
//                           new Round {
//                                Id = 1,
//                                Nom = "round 1",
//                                Matchs = new List<Match>()
//                                {
//                                    new Match
//                                    {
//                                       // EquipeA = new Joueur ()
//                                    }

//                                }
//                            }
//                        }
//                   }
//                }
//            };
            
//            StockageSQLite.RepertoireCompetitions.Ajouter(competition);
//        }



//        [Fact]
//        public void AjouterEtRetrouverCompetition()
//        {
           
//        }

//        public void Dispose()
//        {
//            System.IO.File.Delete(dbFilePath);
//        }
//    }
//}
