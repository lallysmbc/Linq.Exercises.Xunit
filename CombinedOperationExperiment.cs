﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq.Exercises.Xunit
{
    public class CombinedOperationExperiment
    {
        // Useful for turning this into query syntax: 
        // http://jesseliberty.com/2011/01/27/linq-and-fluent-programming/
        // A query syntax example using the "let" keyword to create variables in the middle of the statement: https://msdn.microsoft.com/en-us/library/bb383976.aspx
        // 101 Linq Samples (but they all use query syntax): https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack

        private List<Person> _people = new List<Person>
            {
                new Person { FirstName = "Jean" },
                new Person { FirstName = "Jack" },
                new Person { FirstName = "Jill" },
                new Person { FirstName = "Jiminy" }
            };

        [Fact]
        public void CanUseLinqToFindAllLettersWhichAreRepeatedAcrossSeveralNames()
        {
            List<List<char>> names = _people
                .Select(person => person.FirstName.ToList())
                .ToList();

            var result = names
                .Skip(1)
                .Aggregate(
                    new Thing1
                    {
                        PreviousElements = new List<List<char>> { names[0] },
                        CharactersInCommon = new List<char>()
                    },
                    (resultSoFar, nextElement) =>
                        new Thing1()
                        {
                            PreviousElements = resultSoFar.PreviousElements.Union(new List<List<char>> { nextElement }).ToList(),
                            CharactersInCommon = resultSoFar.PreviousElements
                                .Aggregate(
                                    nextElement.Intersect(resultSoFar.PreviousElements[0])
                                        .ToList(),
                                    (backResultSoFar, nextBackElement) =>
                                    backResultSoFar.Union(
                                        nextElement
                                        .Intersect(nextBackElement))
                                        .ToList())
                                .Union(resultSoFar.CharactersInCommon)
                                .ToList()
                        }).CharactersInCommon;

            Assert.True(result.OrderBy(x => x).SequenceEqual(new char[] { 'a', 'i', 'J', 'n' }.OrderBy(x => x)));
        }
    }

    public class Thing2
    {
        public List<char> CurrentElement { get; set; }
        public List<char> BackCharactersInCommon { get; set; }
    }

    public class Thing1
    {
        public List<List<char>> PreviousElements { get; set; }
        public List<char> CharactersInCommon { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
    }
}
