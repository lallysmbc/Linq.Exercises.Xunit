﻿using System;
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

    public class CombinedOperations
    {
        // we have a list of people
        // we have their first names
        // i need you to find out which letters are common
        // to all the first names

        // Hint: try to use set operations.
        // There are many ways to solve this.
        [Fact]
        public void GetCharactersCommonToEveryonesFirstNamesUsingSetElements_ReturnCharEnumerable()
        {
            // See CombinedOperationExperiment for another way of doing this!

            List<char> result = TestData.People[0].FirstName.ToCharArray()
                .Intersect(TestData.People[1].FirstName.ToCharArray())
                .Intersect(TestData.People[2].FirstName.ToCharArray())
                .Intersect(TestData.People[3].FirstName.ToCharArray())
                .ToList();

            List<char[]> listOfCharArrays = TestData.People
                .Select(x => x.FirstName.ToCharArray())
                .ToList();

            var intersection = listOfCharArrays
                .Aggregate(
                    new Thing
                    {
                        PreviousElement = listOfCharArrays.First(),
                        CurrentIntersection = listOfCharArrays.First()
                    },
                    (previousResult, nextElement) => new Thing
                    {
                        PreviousElement = nextElement,
                        CurrentIntersection = previousResult.PreviousElement.ToList().Intersect(nextElement.ToList())
                    }
                );
            //.GroupBy(x => x)
            //.Where(group => group.Count() > 1)
            //.Select(x => x.Key);

            List<char> commonCharacters = TestData.People[0].FirstName.ToCharArray().ToList();
            //    .Select(x => x.FirstName.ToCharArray())
            //    .ToList();
            //    .Union()
            //    .Distinct()
            //    ToArray(); // please edit/complete so that the test passes

            Assert.True(commonCharacters.OrderBy(x => x).SequenceEqual(new char[] { 'a', 'i', 'J' }.OrderBy(x => x)));
        }

        // Bonus Question
        // we have a list of people
        // we have their first names
        // i need you to find out which letters are common
        // to all the first names names
        // But you are not allowed to use set operations.
        [Fact]
        public void GetCharactersCommonToEveryonesFirstNamesNotUsingSetOperations_ReturnCharEnumerable()
        {
            IEnumerable<char> result = new List<char>();

            Assert.True(result.OrderBy(x => x).SequenceEqual(new char[] { 'a', 'i', 'J' }.OrderBy(x => x)));
        }
    }

    class Thing
    {
        public char[] PreviousElement { get; set; }
        public IEnumerable<char> CurrentIntersection { get; set; }
    }
}
