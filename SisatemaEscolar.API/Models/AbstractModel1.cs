namespace SisatemaEscolar.API.Models
{
    public  abstract class AbstractModel<T> where T : class
    {
        public abstract void SetEntitie(T entity);
        public abstract void GetEntitie(T entity);
    }
}