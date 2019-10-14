namespace Cobad.Domaine.Metier.Createurs
{
    public interface ICreateurCollectif
    {
        Collectif Creer();
        CreateurCollectif DontLeNomEst(string nom);
    }
}