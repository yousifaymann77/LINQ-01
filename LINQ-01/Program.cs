using LINQ.Models;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using static LINQ.DataSources.Source;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Q01 Get all products from the "Seafood" category. Print each product's name and price.
            var seafood = ProductList.Where(p => p.Category == "Seafood").Select(s => new { s.ProductName, s.UnitPrice });
            foreach (var s in seafood)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region 2. Get a list of only the product names from ProductList. Print each name.
            var names = ProductList.Select(s => s.ProductName);
            foreach(var n in names)
            {
                Console.WriteLine(n);
            }
            #endregion

            #region 3. Sort all products by UnitPrice (ascending). Print each product's name and price.
             var sortProds = ProductList.OrderBy(p => p.UnitPrice).Select(s => new { s.ProductName, s.UnitPrice });
            foreach (var s in sortProds)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region 4. Get all products where UnitPrice is between 10 and 30
            var priceRange = ProductList.Where(p => p.UnitPrice >= 10.0000m && p.UnitPrice <= 30.0000m).Select(p => new { p.ProductName, p.UnitPrice });

            foreach(var p in priceRange)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region 5. Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
            var condiments = ProductList.Where(p => p.UnitsInStock > 0 && p.Category.Contains("Condiments")).Select(p => p);
            foreach (var c in condiments)
            {
                Console.WriteLine(c);
            }
            #endregion


            #region 6. Create a new anonymous type
            var newType = ProductList.Select(n => new {Name = n.ProductName , price = n.UnitPrice , stockStatus = n.UnitsInStock > 0 ? "Available" : "Out of stock" });
            foreach (var nt in newType)
            {
                Console.WriteLine(nt);
            }
            #endregion

            #region 7. Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.
            var position = ProductList.Select((p, i) => $"{i+1}.{p.ProductName} , ");
            foreach (var p in position)
            {
                Console.Write(p);
            }
            #endregion

            #region 8. Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.
            var sort = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var s in sort)
            {
                Console.WriteLine(s);
            }
            #endregion

            Console.WriteLine();

            #region 9. Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.
            var Result = ProductList.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock).Select(p => new { p.ProductName, p.UnitsInStock });
            foreach(var p in Result)
            {
                Console.WriteLine(p);
            };
            #endregion


            #region 10. Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate.
            var Result1 = from c in CustomerList
                          from o in c.Orders
                          where o.OrderDate.Year >= 1997
                          select new { c.CustomerID, o.OrderDate };
            foreach (var r in Result1)
            {
                Console.WriteLine(r);
            }
            #endregion


            #region 11. Show position number alongside ProductName
            var Result2 = (from p in ProductList
                          select p.ProductName).Select((n, i) => $"{i + 1}. {n}");
            foreach (var r in Result2)
            {
                Console.WriteLine(r);
            }

            #endregion


            #region 12. Sort first by-word length and then by a case -insensitive sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; 

            var Result3 = Arr.OrderBy(s => s.Length).ThenBy(s => s, StringComparer.OrdinalIgnoreCase);
            foreach (var r in Result3)
            {
                Console.WriteLine(r);
            }
            #endregion

            #region 13. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array
            var Result4 = Arr.Where(w =>char.ToLower(w[1]) == 'i').Reverse().ToList();
            foreach (var r in Result4)
            {
                Console.WriteLine(r);
            }
            #endregion
        }
    }
}
