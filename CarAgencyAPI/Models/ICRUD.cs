using System.Collections.Generic;

namespace CarAgencyAPI.Models
{ 
    public interface ICRUD<T>
    {
        public IEnumerable<T> GetAll();
        public T Create(T t);
        public T GetById(int id);
        public T Update(T t,int id);
        public void Delete(int id);
    }
}
