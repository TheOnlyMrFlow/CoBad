namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurClub
    {
        ICreateurClub DontLeNumeroEst(string numero);
        ICreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona);
        Club Creer();
    }
}