using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
            => People.OrderByDescending(p => p.Age).ToList().First();

        public List<Person> GetMembersByAge(int age)
            => People.Where(p => p.Age > age).OrderBy(p=>p.Name).ToList();

    }
}
