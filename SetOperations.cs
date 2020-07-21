﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Linq.Exercises.Xunit
{
    /// <summary>
    /// Your task is to apply LINQ `Distinct/Union/Intersect/Except/OrderBy` methods,
    /// so all tests will be passed.
    /// Make sure to preview test data located in TestData.cs file.
    /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result`
    /// variable will have expected value(s).
    /// Errata: please post an issue on github.
    /// Look here for a primer: https://code.msdn.microsoft.com/LINQ-Set-Operators-374f34fe
    /// But even better is to start at the MSDN pages for the above methods
    /// </summary>
    /// 

    public class SetOperations
    {
        // I want to see an enumerable which contains only the unique numbers in the
        // above array

        [Fact]
        public void GetDistinctNumbers_ReturnIEnumerable()
        {
            int[] randomNumbers = { 2, 2, 3, 5, 5, 2, 3, 4, 6, 4, 3, 8, 7, 5, 9, 4, 6, 3, 6, 34, 2, 2, 5, 7, 5, 4, 2, 6, 67, 5 };

            IEnumerable<int> result = randomNumbers;

            Assert.True(result.SequenceEqual(new int[] { 2, 3, 5, 4, 6, 8, 7, 9, 34, 67 }));
        }

        // get the unique numbers
        // from both arrays combined
        // in ascending order from 1...9
        [Fact]
        public void GetUniqueNumbersFromTwoArraysInAscendingOrder_ReturnEnumerable()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> result = numbersA;

            Assert.True(result.SequenceEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }

        [Fact]
        public void GetCommonValuesSharedByBothArrays_ReturnEnumerable()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> result = numbersA;

            Assert.True(result.SequenceEqual(new int[] { 5, 8 }));
        }

        [Fact]
        public void GetNumbersInFirstArrayThatAreNotAlsoInSecondArray_ReturnIenumerableInt()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> result = numbersA;

            Assert.True(result.OrderBy(x => x).SequenceEqual(new int[] { 0, 2, 4, 6, 9 }.OrderBy(x => x)));
        }

        [Fact]
        public void GetStringsInFirstArrayThatAreNotAlsoInSecondArray_ReturnIenumerableString()
        {
            string[] lettersA = { "a", "b", "c", "d", "e" };
            string[] lettersB = { "a", "c", "e" };

            IEnumerable<string> result = lettersA;

            Assert.True(result.OrderBy(x => x).SequenceEqual(new string[] { "b", "d" }));
        }
    }
}
