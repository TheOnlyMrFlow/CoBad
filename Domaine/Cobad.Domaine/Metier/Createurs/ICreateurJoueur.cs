namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurJoueur
    {
        ICreateurJoueur DontLaLicenceEst(int license);

        ICreateurJoueur DontLeClubPorteLeNumero(string numeroClub);
        ICreateurJoueur DontLesChampsPoonaSont(Joueur.ChampsPoona champsPoona);
        Joueur Creer();
    }
}