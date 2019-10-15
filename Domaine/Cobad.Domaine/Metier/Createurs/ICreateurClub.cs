namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurClub
    {
        CreateurClub DontLeNumeroEst(string numero);
        CreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona);
        Club Creer();
    }
}