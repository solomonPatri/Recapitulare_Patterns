﻿using Recapitulare_Patterns.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.exceptions
{
    public  class UserAlreadyExistException:Exception
    {

        public UserAlreadyExistException() : base(ExceptionMessages.UserAlreadyExistException)
        {


        }





    }
}