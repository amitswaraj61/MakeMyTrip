//-----------------------------------------------------------------------
// <copyright file="MakeMyTripTest.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using MakeMyTrip.Page;
using NUnit.Framework;

namespace MakeMyTrip.TestCase
{
    /// <summary>
    /// create MakeMyTrip class
    /// </summary>
    [TestFixture]
    public class MakeMyTripTest : Base
    {
        /// <summary>
        /// create Credentials object
        /// </summary>
        Credentials credentails = new Credentials();

        /// <summary>
        /// create Valid Login test
        /// </summary>
        [Test, Order(1)]
        public void ValidLogin()
        {
            Login login = new Login(driver);
            login.LoginToMakeMyTrip(credentails.email, credentails.password);
            string expected = "Hey Amit";
            Assert.AreEqual(expected, login.UserNameValidation());
        }

        /// <summary>
        /// create search flight test
        /// </summary>
        [Test, Order(2)]
        public void SearchFlight()
        {
            SearchFlight search = new SearchFlight(driver);
            search.Search();
            string expected = "Flights from Mumbai to Bengaluru, and back";
            Assert.AreEqual(expected, search.SearchFlightValidation());
        }
        /// <summary>
        /// create Print Flight test
        /// </summary>
        [Test, Order(3)]
        public void PrintFlight()
        {
            PrintTotalFlight print = new PrintTotalFlight(driver);
            print.PrintFlight();
            string expected = "₹ 7,013";
            Assert.AreEqual(expected, print.Validation());
        }

        /// <summary>
        /// create Logout test
        /// </summary>
        [Test, Order(4)]
        public void Logout()
        {
            Logout logout = new Logout(driver);
            logout.LogoutToMakeMyTrip();
        }
    }
}

