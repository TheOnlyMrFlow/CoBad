namespace Cobad.Domaine.Metier.Modificateurs
{
    public interface IModificateurClub
    {
        IModificateurClub ModifierLesChampsPoona(Club.ChampsPoona champsPoona);
        IModificateurClub AjouterPersonnel(Personnel personnel);
        IModificateurClub RetirerPersonnel(string nom); 
        Club Sauvegarder();
    }
}