using System.Collections.Generic;

namespace CarAgencyAPI.Models
{ 
    public interface ICRUD<T>
    {
        public IList<T> GetAll();
        public T Create(T t);
        public T GetById(int id);
        public T Update(T t);
        public void Delete(int id);
    }
}
