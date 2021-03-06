﻿using System;
using System.Collections.Generic;

namespace Linq.Exercises.Xunit
{
    internal static class TestData2
    {
        internal static IEnumerable<int> Numbers
        {
            get
            {
                return new[] { 1, -3, 1, -1, 2, -4, 3, -1, 5, -5 };
            }
        }

        internal static ICollection<string> Animals
        {
            get
            {
                return new[] { "tiger", "lion", "swordfish", "penguin", "elephant", "shark" };
            }
        }

        internal static IList<Person> People
        {
            get
            {
                return new[]
                {
                    new Person("Jack", "Tuck", new DateTime(1990, 3, 12), "SK2"),
                    new Person("Jean", "Gean", new DateTime(1950, 12, 1), "M1l"),
                    new Person("Jill", "Lill", new DateTime(2001, 5, 21), "SA2"),
                    new Person("Jimmy", "Jilly", new DateTime(1974, 9, 16), "M11"),
                };
            }
        }

        internal class Address
        {
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string PostCode { get; set; }
            public DateTime DateFrom { get; set; }
            public Person Person { get; set; }
        }

        internal class Person
        {
            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public DateTime Born { get; private set; }

            public Address Address { get; set; }

            public Person(string firstname, string lastname, DateTime born, string postcode)
            {
                this.FirstName = firstname ?? string.Empty;
                this.LastName = lastname ?? string.Empty;
                this.Born = born;
                this.Address = new Address
                {
                    Person = this,
                    PostCode = postcode
                };
            }

            public override string ToString()
            {
                return string.Format("{{ {0} {1}; {2:yyyy-MM-dd} }}", FirstName, LastName, Born);
            }

            public override int GetHashCode()
            {
                // overflow is fine
                unchecked
                {
                    int hash = 17;
                    // test data should never be null
                    hash = hash * 23 + FirstName.GetHashCode();
                    hash = hash * 23 + LastName.GetHashCode();
                    hash = hash * 23 + Born.GetHashCode();
                    return hash;
                }
            }

            public override bool Equals(Object obj)
            {
                Person person = obj as Person;
                if (person == null)
                {
                    return false;
                }

                return FirstName.Equals(person.FirstName) && LastName.Equals(person.LastName) && Born.Equals(person.Born);
            }
        }

        /// <summary>
        /// The following Data was using for the partioning Tests
        /// </summary>
        ///
        internal static IEnumerable<int> PartitionNumbers
        {
            get
            {
                return new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            }
        }

        /// <summary>
        /// The following Data was using for the Orderby Tests
        /// </summary>
        ///

        internal static IEnumerable<string> OrderByWords
        {
            get { return new string[] { "cherry", "apple", "blueberry" }; }
        }

        internal static IEnumerable<string> OrderByWordsExtended
        {
            get { return new string[] { "cherry", "apple", "blueberry", "tamarind", "zuchini" }; }
        }
    }
}
