using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq.Exercises.Xunit
{
    /// <summary>
    /// Your task is to apply LINQ `Where` method, so all tests will be passed.
    /// Make sure to preview test data located in TestData.cs file.
    /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result` variable will have expected value(s).
    /// </summary>
    public class Restriction
    {
        [Fact]
        public void Where_n_is_greater_than_1_return_3_ints()
        {
            // First test is solved to show you how to use these exercises.
            IEnumerable<int> result = TestData.Numbers.Where(n => n > 1);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Where_n_is_less_than_or_equal_to_0_returns_expected_ints()
        {
            IEnumerable<int> result = TestData.Numbers;

            Assert.Equal(5, result.Count());
            Assert.True(new[] { -3, -1, -4, -1, -5 }.SequenceEqual(result));
        }

        [Fact]
        public void Where_n_multiplied_by_2_is_greater_than_5()
        {
            IEnumerable<int> result = TestData.Numbers;

            Assert.True(new[] { 3, 5 }.SequenceEqual(result));
        }

        [Fact]
        public void Where_n_is_even()
        {
            IEnumerable<int> result = TestData.Numbers;

            Assert.True(new[] { 2, -4 }.SequenceEqual(result));
        }

        [Fact]
        public void Where_index_of_n_is_odd()
        {
            IEnumerable<int> result = TestData.Numbers;

            Assert.True(new[] { 1, 1, 2, 3, 5 }.SequenceEqual(result));
        }

        [Fact]
        public void Where_n_is_even_and_n_is_less_than_0()
        {
            IEnumerable<int> result = TestData.Numbers;

            Assert.True(new[] { -4 }.SequenceEqual(result));
        }

        [Fact]
        public void Where_n_quare_minus_2_times_n_is_greater_than_n()
        {
            // n * n - 2 * n
            IEnumerable<int> result = TestData.Numbers;

            Assert.True(new[] { -3, -1, -4, -1, 5, -5 }.SequenceEqual(result));
        }

        [Fact]
        public void Where_string_length_is_shorter_than_5_letters_returns_1_string()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Where_string_length_is_9_returns_expected_strings()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.Single(result);
            Assert.True(new[] { "swordfish" }.SequenceEqual(result));
        }

        [Fact]
        public void Where_string_starts_with_s()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.True(new[] { "swordfish", "shark" }.SequenceEqual(result));
        }

        [Fact]
        public void Where_string_has_i_as_a_second_letter()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.True(new[] { "tiger", "lion" }.SequenceEqual(result));
        }

        [Fact]
        public void Where_string_contains_e()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.True(new[] { "tiger", "penguin", "elephant" }.SequenceEqual(result));
        }

        [Fact]
        public void Where_string_ends_with_uppercase_t()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.True(new[] { "elephant" }.SequenceEqual(result));
        }

        [Fact]
        public void Where_substring_equals_to_io()
        {
            IEnumerable<string> result = TestData.Animals;

            Assert.True(new[] { "lion" }.SequenceEqual(result));
        }

        [Fact]
        public void Where_person_firstname_and_lastname_starts_with_same_letter()
        {
            IEnumerable<TestData.Person> result = TestData.People;

            Assert.True(new[] { TestData.People[3] }.SequenceEqual(result));
        }

        [Fact]
        public void Where_person_was_born_before_1990()
        {
            IEnumerable<TestData.Person> result = TestData.People;

            Assert.True(new[] { TestData.People[1], TestData.People[3] }.SequenceEqual(result));
        }

        [Fact]
        public void Where_person_was_born_on_day_with_even_number()
        {
            IEnumerable<TestData.Person> result = TestData.People;

            Assert.True(new[] { TestData.People[0], TestData.People[3] }.SequenceEqual(result));
        }

        [Fact]
        public void Where_person_was_born_on_monday_21st()
        {
            IEnumerable<TestData.Person> result = TestData.People;

            Assert.True(new[] { TestData.People[2] }.SequenceEqual(result));
        }

        [Fact]
        public void Where_person_had_18_years_or_more_in_2000()
        {
            IEnumerable<TestData.Person> result = TestData.People;

            Assert.True(new[] { TestData.People[1], TestData.People[3] }.SequenceEqual(result));
        }

        [Fact]
        public void Where_person_lastname_contains_ll_and_sum_of_year_month_day_is_greater_than_2000()
        {
            IEnumerable<TestData.Person> result = TestData.People;

            Assert.True(new[] { TestData.People[2] }.SequenceEqual(result));
        }
    }
}
