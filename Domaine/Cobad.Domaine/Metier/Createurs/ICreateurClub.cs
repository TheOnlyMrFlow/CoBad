namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurClub
    {
        Club Creer();
        CreateurClub DontLesChampsPoonaSont(Club.ChampsPoona champsPoona);
    }
}