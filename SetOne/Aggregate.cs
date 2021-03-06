﻿using System;
using System.Linq;
using Xunit;

namespace Linq.Exercises.Xunit.SetOne
{
    public class Aggregate
    {
        /// <summary>
        /// Your task is to apply LINQ `Count/Sum/Min/Max/Average/Aggregate` methods, so all tests will be passed.
        /// Make sure to preview test data located in TestData.cs file.
        /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result` variable will have expected value(s).
        /// </summary>
        [Fact]
        public void Count_all_numbers()
        {
            // First test is solved to show you how to use these exercises.
            var result = TestData.Numbers.Count();

            Assert.Equal(10, result);
        }

        [Fact]
        public void Count_all_occurences_of_1()
        {
            var result = TestData.Numbers.Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Count_all_animals_having_character_count_equal_to_5()
        {
            // Hint: use nested count
            var result = TestData.Animals.Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Sum_all_numbers()
        {
            var result = TestData.Numbers.Count();

            Assert.Equal(-2, result);
        }

        [Fact]
        public void Sum_all_characters_in_animal_names()
        {
            var result = TestData.Animals.Count();

            Assert.Equal(38, result);
        }

        [Fact]
        public void Sum_all_birth_years()
        {
            var result = TestData.People.Count();

            Assert.Equal(7915, result);
        }

        [Fact]
        public void Find_minimum_number()
        {
            var result = TestData.Numbers.Count();

            Assert.Equal(-5, result);
        }

        [Fact]
        public void Find_length_of_shortest_animal_name()
        {
            var result = TestData.Animals.Count();

            Assert.Equal(4, result);
        }

        [Fact]
        public void Find_earliest_birthday()
        {
            var result = TestData.People.Count();

            //Correct linq statement then uncomment assert
            //Assert.Equal(new DateTime(1950, 12, 1), result);
        }

        [Fact]
        public void Find_maximum_number()
        {
            var result = TestData.Numbers.Count();

            Assert.Equal(5, result);
        }

        [Fact]
        public void Find_length_of_longest_animal_name()
        {
            var result = TestData.Animals.Count();

            Assert.Equal(9, result);
        }

        [Fact]
        public void Find_latest_birthday()
        {
            var result = TestData.People.Count();

            //Correct linq statement then uncomment assert
            //Assert.Equal(new DateTime(2001, 5, 21), result);
        }

        [Fact]
        public void Find_average_of_numbers()
        {
            var result = TestData.Numbers.Count();

            Assert.Equal(-0.2, result);
        }

        [Fact]
        public void Find_average_of_birth_years()
        {
            var result = TestData.People.Count();

            Assert.Equal(1978.75, result);
        }

        [Fact]
        public void Aggregate_Sum_of_all_numbers()
        {
            // Aggregate is a little bit more complicated
            // so first test is solved to show you how to use it.
            // 0 = inital value of sum
            // sum = accumalator
            // nextValue = current value in sequence
            var result = TestData.Numbers.Aggregate(0, (sum, nextValue) => sum + nextValue);

            Assert.Equal(-2, result);
        }

        [Fact]
        public void Aggregate_Product_of_all_numbers()
        {
            // Hint: product is a result of multiplication
            int result = TestData.Numbers.Aggregate((product, nextValue) => 1);

            Assert.Equal(-1800, result);
        }

        [Fact]
        public void Aggregate_Secret_formula()
        {
            // secret formula is as follows
            // start with 256
            // for each person take the day of her/his birth date
            // if this day is bigger than 15, then substract 10 from it
            // else add 5 to it
            // and add resulting number to your aggregate

            var result = TestData.People.Aggregate(0, (sum, person) =>
            {
                return sum;
            });

            Assert.Equal(296, result);
        }
    }
}
