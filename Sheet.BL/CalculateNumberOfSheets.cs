using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSheet
{
    public static class CalculateNumberOfSheets
    {
        public static List<Product> ListOfProduct { get; set; } = new List<Product>();
        public static Sheet Sheet { get; set; }


        public static int GetNumberOfSheets()
        {

            // Determines the currentRow max height
            int maxCurrentRowHeight = 0;

            // Determines the rest of a row width
            int currentRowWidth = Sheet.Width;

            //Determines what rests of the current Sheet Height
            int currentSheetHeight = Sheet.Height;

            // Determines the number  of sheets needed to print the list of products
            // Initiliazed to 1
            int numberOfSheets = 1;

            foreach(var product in ListOfProduct)
            {
                // 1- First we verify if we can add a product to the current line
                if ( product.Width <= currentRowWidth)
                {
                    currentRowWidth -= product.Width;

                    if (product.Height >= maxCurrentRowHeight && product.Height <= currentSheetHeight)
                    {
                        maxCurrentRowHeight = product.Height;
                        currentSheetHeight -= maxCurrentRowHeight;
                    }
                    else
                    {
                        maxCurrentRowHeight = 0;
                        currentRowWidth = Sheet.Width;
                        currentSheetHeight = Sheet.Height;
                        numberOfSheets++;
                    }
                }
                // 2- Update the SheetHeight and going to the next line 
                // if the remaining sheet height is inferior the product height 
                // we require a new sheet, so we would increment the number of sheets 
                // and intiate the values added
                else
                {
                    if(currentSheetHeight > 0 && currentSheetHeight > product.Height)
                    {
                        currentRowWidth = Sheet.Width;
                    }
                    else
                    {
                        maxCurrentRowHeight = 0;
                        currentRowWidth = Sheet.Width;
                        currentSheetHeight = Sheet.Height;
                        numberOfSheets ++;
                    }
                }

            }
            return numberOfSheets;

        }
    }
}
