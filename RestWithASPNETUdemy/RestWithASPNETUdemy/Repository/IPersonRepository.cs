using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long personId);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long personId);
        bool Exists(long id);
    }
}