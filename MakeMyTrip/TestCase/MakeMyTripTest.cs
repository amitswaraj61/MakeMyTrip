using MakeMyTrip.Page;
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
        [Test, Order(3)]
        public void PrintFlight()
        {

            PrintTotalFlight print = new PrintTotalFlight(driver);
            print.PrintFlight();
            string expected = "₹ 7,013";
            Assert.AreEqual(expected, print.Validation());
        }
        [Test, Order(4)]
        public void Logout()
        {
            Logout logout = new Logout(driver);
            logout.LogoutToMakeMyTrip();
        }
    }
}

