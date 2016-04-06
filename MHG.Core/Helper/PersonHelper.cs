using System.Collections.Generic;
using System.Linq;

namespace MHG.Core.Helper
{
    public class PersonHelper
    {
        List<Person.Person> list;

        public List<string> GetPersonsName()
        {
            return list.Select(T => T.Name + " " + T.Surname).ToList();
        }

        public Person.Person Add(Person.Person person)
        {
            list.Add(person);
            return person;
        }
    }
}
