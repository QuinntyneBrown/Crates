﻿using System;

namespace Crates.Api.Exceptions
{
    public class DomainException: Exception
    {
        public DomainException(string message = null)
            :base(message)
        {

        }
    }
}
