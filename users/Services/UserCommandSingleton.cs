using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public class UserCommandSingleton
    {

        private static IUserCommandService _serviceCommand = null;

        private UserCommandSingleton() { 
        
        
        
        }

        public static IUserCommandService ServiceCommand
        {

            get
            {
                if (_serviceCommand == null)
                {
                    _serviceCommand = new UserComandService();





                }
                return _serviceCommand;
            }







        }













    }
}
