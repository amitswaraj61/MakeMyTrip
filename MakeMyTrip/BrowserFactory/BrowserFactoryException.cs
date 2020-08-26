//-----------------------------------------------------------------------
// <copyright file="BrowserFactoryException.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace MakeMyTrip.BrowserFactory
{
    /// <summary>
    /// BrowserFactoryException class
    /// </summary>
    public class BrowserFactoryException:Exception
    {
        public String message;
        public ExceptionType type;

        /// <summary>
        /// craete Enum of Exception type
        /// </summary>
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION , MAIL_NOT_SEND,INTERNET_NOT_AVAILABLE
        }

        /// <summary>
        /// create Browser Factory exception method
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public BrowserFactoryException(String message, ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
