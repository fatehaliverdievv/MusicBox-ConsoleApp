﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicboxtask.Exceptions
{
    internal class WrongCommandException:Exception
    {
        public WrongCommandException(string message):base(message)
        {
        }
    }
}
