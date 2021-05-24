using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long personId);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long personId);
    }
}