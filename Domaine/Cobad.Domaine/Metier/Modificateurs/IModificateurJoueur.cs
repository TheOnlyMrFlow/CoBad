namespace Cobad.Domaine.Metier.Modificateurs
{
    public interface IModificateurJoueur
    {
        IModificateurJoueur SetMail(string mail);
        IModificateurJoueur SetTelephone(string telephone);
        Joueur Sauvegarder();
    }
}