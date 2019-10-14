namespace Cobad.Domaine.Metier.Modificateurs
{
    public interface IModificateurClub
    {
        IModificateurClub AjouterPersonnel(Personnel personnel);
        IModificateurClub RetirerPersonnel(string nom);
        Club Sauvegarder();
    }
}