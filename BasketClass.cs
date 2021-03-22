using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Basket
    {
        Item[] Items;
        public double TotalPrice();
        public void Checkout();
        private bool VerifyCard(string cardNumber);
        private void ShowReservationCode();
        private void ShowPaymentError();

    }
}


