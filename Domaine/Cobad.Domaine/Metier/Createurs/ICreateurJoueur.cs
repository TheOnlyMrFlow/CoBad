namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurJoueur
    {
        CreateurJoueur DontLaLicenceEst(int license);
        CreateurJoueur DontLesChampsPoonaSont(Joueur.ChampsPoona champsPoona);
        Joueur Creer();
    }
}