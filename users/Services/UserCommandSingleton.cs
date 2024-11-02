using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public class UserCommandSingleton
    {

        private static IUserCommandService instance = null;

        private UserCommandSingleton() { 
        
        
        
        }

        public static IUserCommandService Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new UserComandService();





                }
                return instance;
            }







        }













    }
}
