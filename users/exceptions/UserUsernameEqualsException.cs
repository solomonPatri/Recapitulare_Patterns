using Recapitulare_Patterns.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.exceptions
{
    public class UserUsernameEqualsException:Exception
    {

        public UserUsernameEqualsException() : base(ExceptionMessages.UserUsernameEqualsException)
        {

        }


    }
}
