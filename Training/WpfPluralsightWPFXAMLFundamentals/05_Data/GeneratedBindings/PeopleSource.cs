using System.Collections.Generic;

namespace GeneratedBindings
{
    public class PeopleSource
    {
        public List<Person> People { get; private set; }

        public PeopleSource()
        {
            this.People = new List<Person>();
            this.People.Add(new Person { Name = "Ian", Age = 34.6 });
            this.People.Add(new Person { Name = "Mike", Age = 62.5 });
            this.People.Add(new Person { Name = "Brian", Age = 3.5 });
        }
    }
}
