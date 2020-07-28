using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq.Exercises.Xunit.Projection
{
    public class Projection
    {
        /// The select clause of a LINQ query projects the output sequence. It transforms each input element into the shape of the output sequence
        
        /// <summary>
        /// Your task is to apply LINQ `Select/SelectMany` methods, so all tests will be passed.
        /// Make sure to preview test data located in TestData.cs file.
        /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result` variable will have expected value(s).
        /// </summary>
        [Fact]
        public void Produce_A_Sequence_Of_Ints_One_Higher_Than_Those_In_An_Existing_Array()
        {
            //It demonstrates how select can modify the input sequence
            #region Test data answer

            var data = new List<int>{ 2, -2, 2, 0, 3, -3, 4, 0, 6, -4 };
            #endregion

            var result = TestData3.Numbers.Select(_ => _ + 1);

            Assert.True(result.SequenceEqual(data));
        }

        [Fact]
        public void Produce_A_Sequence_Of_Just_The_ProductName_In_A_List_Of_Products()
        {
            #region Test data answer

            var data = new List<string> { "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning" };
            #endregion

            var result = TestData3.Products.Select(_ => _.ProductName);

            Assert.True(result.SequenceEqual(data));
        }

        [Fact]
        public void Produce_A_NewList_Of_SMBCProduct_Objects_Representing_The_ProductName_And_CategoryCombined()
        {
            //check SMBCProduct object in TestData3
            #region Test data answer

            var data = new List<SMBCProduct> { new SMBCProduct { FullName = "Chai Beverages" }, new SMBCProduct { FullName = "Chang Beverages" }, new SMBCProduct { FullName = "Aniseed Syrup Condiments" }, new SMBCProduct { FullName = "Chef Anton's Cajun Seasoning Condiments" } };
            #endregion

            var result = TestData3.Products.Select(_ => new SMBCProduct { FullName = $"{_.ProductName} {_.Category}" });

            Assert.Equal(data.First().FullName, result.First().FullName);
            Assert.Equal(data.Last().FullName, result.Last().FullName);
        }

        [Fact]
        public void Produce_A_NewList_Of_Annoymous_Objects_Representing_The_ProductName()
        {
            #region Test data answer

            var item1 = new { ProductName = "Chai" };
            var item2 = new { ProductName = "Chang" };
            var item3 = new { ProductName = "Aniseed Syrup" };
            var item4 = new { ProductName = "Chef Anton's Cajun Seasoning" };
            #endregion

            var result = TestData3.Products.Select(_ => new { _.ProductName });

            Assert.Equal(item1.ProductName, result.ToList()[0].ProductName);
            Assert.Equal(item2.ProductName, result.ToList()[1].ProductName);
            Assert.Equal(item3.ProductName, result.ToList()[2].ProductName);
            Assert.Equal(item4.ProductName, result.ToList()[3].ProductName);
        }

        [Fact]
        public void Produce_A_NewList_Of_Annoymous_Objects_Representing_If_TheProduct_Is_Available_And_The_ProductName()
        {
            //The product is aviliable if the unitsInStock is > 0
            //return a object which contains ProductName and IsAvailable boolean
            #region Test data answer

            var item1 = new { ProductName = "Chai" };
            var item2 = new { ProductName = "Chang" };
            var item3 = new { ProductName = "Aniseed Syrup" };
            var item4 = new { ProductName = "Chef Anton's Cajun Seasoning" };
            #endregion

            var result = TestData3.Products.Select(_ => new { _.ProductName, IsAvailiable = _.UnitsInStock > 0 });

            Assert.Equal(item1.ProductName, result.ToList()[0].ProductName);
            Assert.False(result.ToList()[0].IsAvailiable);
            Assert.Equal(item2.ProductName, result.ToList()[1].ProductName);
            Assert.True(result.ToList()[1].IsAvailiable);
            Assert.Equal(item3.ProductName, result.ToList()[2].ProductName);
            Assert.False(result.ToList()[2].IsAvailiable);
            Assert.Equal(item4.ProductName, result.ToList()[3].ProductName);
            Assert.True(result.ToList()[3].IsAvailiable);
        }

        [Fact]
        public void Produce_A_Tuple_Representing_If_TheProduct_Is_Available_And_The_ProductName()
        {
            //return same as above but in a tuple.
            #region Info

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#use-cases-of-tuples
            #endregion
            var result = TestData3.Products.Select(_ => ( _.ProductName, IsAvailiable : _.UnitsInStock > 0 ));


            var (ProductName, IsAvailiable) = result.FirstOrDefault();
            var (lastProductName, lastIsAvailiable) = result.LastOrDefault();


            Assert.False(IsAvailiable);
            Assert.True(lastIsAvailiable);
        }

        [Fact]
        public void Produce_A_Sequence_Containing_Some_Properties_Of_Products_Including_UnitPrice_Which_Is_Renamed_To_Price()
        {
            //Properties to include, ProductName, Category and UnitPrice renamed to Price
            var result = TestData3.Products.Select(_ => new { _.ProductName, _.Category, Price = _.UnitPrice});

            Assert.Equal(18.0000M, result.FirstOrDefault().Price);
            Assert.Equal(22.0000M, result.LastOrDefault().Price);
        }

        [Fact]
        public void Produce_A_Tuple_Containing_Some_Properties_Of_Products_Including_UnitPrice_Which_Is_Renamed_To_Price()
        {
            //return same as above but in a tuple.
            var result = TestData3.Products.Select(_ => (_.ProductName, _.Category, Price: _.UnitPrice ));

            Assert.Equal(18.0000M, result.FirstOrDefault().Price);
            Assert.Equal(22.0000M, result.LastOrDefault().Price);
        }

        [Fact]
        public void Produce_A_Sequence_To_Determine_If_The_Value_Of_Ints_In_An_Array_Match_Their_Position_In_The_Array()
        {
            //return bool if the index is same as the value projected. i.e. value = 3, index position 3.
            var result = TestData3.NumbersIndex.Select((num, index) => num == index);

            Assert.Equal(4, result.Count(_ => _));
            Assert.Equal(6, result.Count(_ => !_));
        }

        [Fact]
        public void Produce_A_Sequence_Representing_All_Staff_From_The_List_Of_Schools()
        {
            //return a single list of all staff from the schools data
            var result = TestData3.Schools.SelectMany(_ => _.Staff);

            Assert.Equal(5, result.ToList().Count);
        }

        [Fact]
        public void Produce_A_Sequence_Representing_Only_The_Staff_Names()
        {
            var result = TestData3.Schools.SelectMany(_ => _.Staff).Select(_ => _.Name);

            Assert.Equal("Mrs Teacher", result.First());
            Assert.Equal("Teacher Four", result.Last());
        }

        [Fact]
        public void Produce_A_Sequence_Representing_Staff_And_Determine_If_The_Index_Is_Greater_Than_2_They_Get_Double_Pay()
        {
            //return object/tuple which has DoublePay property;
            var result = TestData3.Schools.SelectMany(_ => _.Staff).Select((_, index) => (_.Name, DoublePay: index > 2));

            Assert.False(result.First().DoublePay);
            Assert.True(result.Last().DoublePay);
        }
    }
}