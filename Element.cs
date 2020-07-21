using System.Linq;
using Xunit;

namespace Linq.Exercises.Xunit
{
    /// <summary>
    /// Your task is to apply LINQ `First/FirstOrDefault/Last/LastOrDefault` methods, so all tests will be passed.
    /// Make sure to preview test data located in TestData.cs file.
    /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result` variable will have expected value(s).
    /// </summary>
    public class Element
    {
        [Fact]
        public void First_n()
        {
            // First test is solved to show you how to use these exercises.
            int result = TestData.Numbers.First();

            Assert.Equal(1, result);
        }

        [Fact]
        public void First_n_less_than_0()
        {
            int result = TestData.Numbers.First();

            Assert.Equal(-3, result);
        }

        [Fact]
        public void Last_n_greater_than_0()
        {
            int result = TestData.Numbers.Last();

            Assert.Equal(5, result);
        }

        [Fact]
        public void First_even_n()
        {
            int result = TestData.Numbers.First();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Last_even_n()
        {
            int result = TestData.Numbers.Last();

            Assert.Equal(-4, result);
        }

        [Fact]
        public void First_n_greater_than_10_if_not_found_return_0()
        {
            int result = TestData.Numbers.First();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Last_n_less_than_minus_1234_if_not_found_return_0()
        {
            int result = TestData.Numbers.Last();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Last_elephant()
        {
            string result = TestData.Animals.Last();

            Assert.Equal("elephant", result);
        }

        [Fact]
        public void First_string_having_4_letters()
        {
            string result = TestData.Animals.First();

            Assert.Equal("lion", result);
        }

        [Fact]
        public void Last_string_containg_g()
        {
            string result = TestData.Animals.Last();

            Assert.Equal("penguin", result);
        }

        [Fact]
        public void First_string_having_s_as_first_letter()
        {
            string result = TestData.Animals.First();

            Assert.Equal("swordfish", result);
        }

        [Fact]
        public void Last_three_letter_long_word_or_null()
        {
            string result = TestData.Animals.Last(s => s.Length == 3);

            Assert.Null(result);
        }

        [Fact]
        public void First_person_born_after_2000()
        {
            TestData.Person result = TestData.People.First();

            Assert.Equal(TestData.People[2], result);
        }

        [Fact]
        public void Last_person_with_lastname_ending_with_l()
        {
            TestData.Person result = TestData.People.Last();

            Assert.Equal(TestData.People[2], result);
        }

        [Fact]
        public void First_person_born_141th_day_of_year()
        {
            TestData.Person result = TestData.People.First();

            Assert.Equal(TestData.People[2], result);
        }

        [Fact]
        public void Last_person_whose_firstname_does_not_start_with_J_or_null()
        {
            TestData.Person result = TestData.People.Last();

            Assert.Null(result);
        }
    }
}
