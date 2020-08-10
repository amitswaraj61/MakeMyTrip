﻿using MakeMyTrip.Page;
using NUnit.Framework;

namespace MakeMyTrip.TestCase
{
    [TestFixture]
    public class MakeMyTripTest : Base
    {
        Credentials credentails = new Credentials();

        [Test, Order(1)]
        public void ValidLogin()
        {
            Login login = new Login(driver);
            login.LoginToMakeMyTrip(credentails.email, credentails.password);

            string expected = "Hey Amit";
            Assert.AreEqual(expected, login.UserNameValidation());
        }

        [Test, Order(2)]
        public void SearchFlight()
        {

            SearchFlight search = new SearchFlight(driver);
            search.Search();
            string expected = "Flights from Mumbai to Bengaluru, and back";
            Assert.AreEqual(expected, search.SearchFlightValidation());
        }
    }
}

