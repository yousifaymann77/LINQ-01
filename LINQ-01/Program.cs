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
        }
    }
}
