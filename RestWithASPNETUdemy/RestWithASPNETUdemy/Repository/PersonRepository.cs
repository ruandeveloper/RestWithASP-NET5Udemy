using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) {}
        
        public Person Disable(long id)
        {
            if (!Exists(id)) return null;

            var person = FindById(id);

            if (person == null) return null;

            person.Enabled = false;

            try
            {
                _context.Entry(person).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return person;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName) 
                         && p.LastName.Contains(lastName)).ToList();
            } 
            
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName) 
                         ).ToList();
            } 
            
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(
                    p => p.LastName.Contains(lastName)).ToList();
            }

            return null;
        }
    }
}