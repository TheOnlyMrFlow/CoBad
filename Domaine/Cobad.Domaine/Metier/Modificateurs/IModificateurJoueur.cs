namespace Cobad.Domaine.Metier.Modificateurs
{
    public interface IModificateurJoueur
    {
        IModificateurJoueur ModifierLesChampsPoona(Joueur.ChampsPoona champsPoona);
        IModificateurJoueur ModifierMail(string mail);
        IModificateurJoueur ModifierTelephone(string telephone);
        Joueur Sauvegarder();
    }
}