using System;
using System.Collections.Generic;

namespace ProductSheet
{
    class Program
    {
        static void Main(string[] args)
        {

            var sheet = new Sheet()
            {
                Height = 100,
                Width = 100
            };

            List<Product> productList = new List<Product>()
            {
                new Product(){ Width = 50, Height = 60 },
                new Product(){ Width = 20, Height = 40},
                new Product(){ Width = 100, Height = 50 },
                new Product(){ Width = 100, Height = 100 },
            };

            CalculateNumberOfSheets.Sheet = sheet;
            CalculateNumberOfSheets.ListOfProduct = productList;

            int result = CalculateNumberOfSheets.GetNumberOfSheets();

            Console.WriteLine("Number of sheets required is {0} ", result);
        }
    }

   

    



}
