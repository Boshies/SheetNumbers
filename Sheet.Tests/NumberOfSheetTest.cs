using ProductSheet;
using System;
using System.Collections.Generic;
using Xunit;

namespace SheetTest
{
    public class NumberOfSheetTest
    {
        [Fact]
        public void SheetNumberTest()
        {
            //1- Arrange 

            var sheet = new Sheet()
            {
                Width = 100,
                Height = 100
            };

            List<Product> productList = new List<Product>()
            {
                new Product(){ Width = 50, Height = 60 },
                new Product(){ Width = 20, Height = 40},
                new Product(){ Width = 100, Height = 50 },
                new Product(){ Width = 100, Height = 100 },
            };

            CalculateNumberOfSheets.ListOfProduct = productList;
            CalculateNumberOfSheets.Sheet = sheet;

            int expectedNumberOfSheet = 3;

            //2- Act
            var currentSheetNumbers = CalculateNumberOfSheets.GetNumberOfSheets();

            //3- Assert
            Assert.Equal(expectedNumberOfSheet, currentSheetNumbers);
        }

        [Fact]
        public void TestEmptyProductList()
        {
            // 1- Arrange
            Sheet defaultSheet = new Sheet();
            List<Product> listOfProduct = new List<Product>();

            CalculateNumberOfSheets.Sheet = defaultSheet;
            
            CalculateNumberOfSheets.ListOfProduct = listOfProduct;

            int expectedOutput = 0;

            // 2 - Act

            var output = CalculateNumberOfSheets.GetNumberOfSheets();

            // 3 - Assert

            Assert.Equal(expectedOutput, output);



        }
    }
}
