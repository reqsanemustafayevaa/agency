﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class NotFoundException:Exception
    {
        public string PropertyName { get; set; }
        
        public NotFoundException(string? message) : base(message)
        {

        }
        public NotFoundException(string propertyName,string? message):base(message)
        {
            PropertyName = propertyName;
        }
    }
}
