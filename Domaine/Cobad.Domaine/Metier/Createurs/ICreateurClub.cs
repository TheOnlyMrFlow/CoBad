namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurClub
    {
        CreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona);
        Club Creer();
    }
}