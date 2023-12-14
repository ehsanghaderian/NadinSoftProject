﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exceptions
{
    public class DomainServiceException : Exception
    {
        public DomainServiceException(string message) : base(message)
        {

        }
    }
}
