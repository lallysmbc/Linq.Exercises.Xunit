using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq.Exercises.Xunit
{    
    /// <summary>
     /// These tests require the combination of various linq methods to arrive at a solution.
     /// Hints as to what these methods are will not be given. The student is required to think 
     /// critically above the problem in hand, and to utilise the full gamut of all the methods
     /// available to him or her.
     /// </summary>
     /// 
    public class OtherOperations
    {
        // Change only one part of the Linq statement to make this test pass
        [Fact]
        public void MeltYourHead1()
        {
            var thing = TestData2.People
                .Select(x => x.Address);

            var thing2 = thing
                .Select(x => x.Person);

            var thing3 = thing2
                .Where(x => x.Something());

            var thng4 = thing3
                .OrderByDescending(x => x.Address.PostCode);

            var results = thng4
                .ToList();

            Assert.Equal(4, results.Count);
        }

        // Change only one part of the Linq statement to make this test pass
        [Fact]
        public void MeltYourHead2()
        {
            var results = TestData2.People
                .Select(x => x.Address)
                .Select(x => x.Person)
                .Where(x => x.Something())
                .OrderByDescending(x => x.Address.PostCode)
                .ToList();

            Assert.Equal("M11", results[0].Address.PostCode);
        }

        // Convert the query syntax to fluent method syntax
        [Fact]
        public void MeltYourHead3()
        {
            var someData = Enumerable.Range(1, 50);
            var result = from n in someData
                         where n > 6
                         select n + n;

            Assert.Equal(18, result.ToList()[2]);
        }

        // Convert the fluent method syntax to query syntax
        [Fact]
        public void MeltYourHead4()
        {
            var someData = Enumerable.Range(1, 50);
            var result = someData
                .Where(n => n > 2)
                .Select(n => n + 2)
                .ToList();

            Assert.Equal(7, result[2]);
        }

        // Convert the declarative syntax to query syntax
        [Fact]
        public void MeltYourHead5()
        {
            var someData = Enumerable.Range(1, 50);
            var result = new List<int>();
            foreach (var n in someData)
            {
                if (n > 5)
                {
                    result.Add(n * n);
                }
            }

            Assert.Equal(36, result[0]);
        }

        // Convert the declarative syntax to fluent method syntax
        [Fact]
        public void MeltYourHead6()
        {
            var someData = Enumerable.Range(1, 50);
            var result = new List<int>();
            foreach (var n in someData)
            {
                if (n > 5)
                {
                    result.Add(n * n);
                }
            }

            Assert.Equal(36, result[0]);
        }

        // Convert the query syntax to fluent method syntax
        [Fact]
        public void MeltYourHead7()
        {
            // More info here: https://msdn.microsoft.com/en-us/library/bb383976.aspx
            string[] strings =
                {
                    "A penny saved is a penny earned.",
                    "The early bird catches the worm.",
                    "The pen is mightier than the sword."
                };

            // Split the sentence into an array of words
            // and select those whose first letter is a vowel.
            var result =
                from sentence in strings
                let words = sentence.Split(' ')
                from word in words
                let w = word.ToLower()
                where w[0] == 'a' || w[0] == 'e'
                    || w[0] == 'i' || w[0] == 'o'
                    || w[0] == 'u'
                select word;

            Assert.Equal("earned.", result.ToList()[3]);
        }
    }
}
