using System;
using System.Collections.Generic;

namespace AwesomeProject
{
    public class VendingMachine
    {

        public static int Shop(List<Item> goodsItems,string item, int money)
        {
            foreach (var goodsItem in goodsItems)
            {
                if (item == goodsItem.name)
                {
                    if (money >= goodsItem.price)
                    {
                        return goodsItem.price;
                    }
                     return 0;
                }
                
            }

            return 0;

        }

    }
}