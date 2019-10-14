namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurJoueur
    {
        Joueur Creer();
        CreateurJoueur DontLesChampsPoonaSont(Joueur.ChampsPoona champsPoona);
    }
}