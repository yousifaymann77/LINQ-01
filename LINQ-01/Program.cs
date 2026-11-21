using LINQ.Models;
using static LINQ.DataSources.Source;

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
        }
    }
}
