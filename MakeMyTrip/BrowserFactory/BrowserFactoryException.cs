using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.BrowserFactory
{
   public class BrowserFactoryException:Exception
    {
        public String message;
        public ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION , MAIL_NOT_SEND,INTERNET_NOT_AVAILABLE
        }

        public BrowserFactoryException(String message, ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
