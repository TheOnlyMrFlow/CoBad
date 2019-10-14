namespace Cobad.Domaine.Metier.Modificateurs
{
    public interface IModificateurCollectif
    {
        IModificateurCollectif AjouterCategorieCible(Categorie categorie);
        IModificateurCollectif AjouterMembre(int licenseDuMembre);
        IModificateurCollectif AjouterMembre(Joueur membre);
        IModificateurCollectif RetirerCategorieCible(Categorie categorie);
        IModificateurCollectif RetirerMembre(int licenseDuMembre);
        IModificateurCollectif RetirerMembre(Joueur membre);
        IModificateurCollectif SetNom();
        Collectif Sauvegarder();
        Collectif SauvegarderOuCreerSiExistePas();
    }
}