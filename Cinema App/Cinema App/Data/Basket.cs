using System;
using System.Collections.Generic;

namespace Cinema_App
{
    class BasketItem
    {
        public Item Item;
        public int Quantity;

        public BasketItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }

    class Basket
    {
        private List<BasketItem> Items = new List<BasketItem>();

        /// <summary>
        /// Get the total price of all Items in the basket.
        /// </summary>
        /// <returns>Total price of all items</returns>
        public double TotalPrice()
        {
            double c = 0.0;

            foreach(BasketItem item in Items)
            {
                c += item.Item.Price * item.Quantity;
            }

            return c;
        }

        public void AddItem(Item item, int quantity = 1)
        {
            Items.Add(new BasketItem(item, quantity));
        }

        public void SetQuantity(Item item, int newQuanity)
        {
            BasketItem bitem = Items.Find(bitem => bitem.Item == item);

            if (bitem != null)
                bitem.Quantity = newQuanity;
            else
                AddItem(item, newQuanity);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(Items.Find(bitem => bitem.Item == item));
        }

        public List<BasketItem> GetAllItems()
        {
            return Items;
        }

        public void EmptyBasket()
        {
            Items.Clear();
        }
    }
}