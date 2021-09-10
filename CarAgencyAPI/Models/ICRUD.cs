namespace CarAgencyAPI.Models
{ 
    public interface ICRUD<T>
    {
        public T Create(T t);
        public T Get(int id);
        public T Update(T t);
        public void Delete(int id);
    }
}
