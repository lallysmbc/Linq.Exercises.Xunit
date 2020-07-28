using System.Collections.Generic;

namespace Linq.Exercises.Xunit
{
    public class TestData3
    {
        public static IEnumerable<int> Numbers => new[] { 1, -3, 1, -1, 2, -4, 3, -1, 5, -5 };
        public static IEnumerable<int> NumbersIndex => new[] { 0, 5, 9, -2, 4, 3, 1, 7, -5, 9 };
        public static IEnumerable<Product> Products => new List<Product> {
            new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 0 },
            new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 0 },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 5 } };

        public static IEnumerable<School> Schools => new List<School>
        {
            new School
            {
                Staff = new List<Staff>
                {
                    new Staff
                    {
                        Name = "Mrs Teacher"
                    },
                    new Staff
                    {
                        Name = "Teacher Two"
                    },
                    new Staff
                    {
                        Name = "Teacher Three"
                    }
                }
            },
            new School
            {
                Staff = new List<Staff>
                {
                    new Staff
                    {
                        Name = "Mr Teacher",
                        OnLeave = true
                    },
                    new Staff
                    {
                        Name = "Teacher Four"
                    }
                }
            }
        };
    }

    public class School
    {
        public List<Staff> Staff { get; set; }
    }

    public class Staff
    {
        public string Name { get; set; }
        public bool OnLeave { get; set; }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class SMBCProduct
    {
        public string FullName { get; set; }
    }
}
