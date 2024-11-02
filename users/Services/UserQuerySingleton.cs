using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public  class UserQuerySingleton
    {

        private static IUserQueryService instance = null;

        private UserQuerySingleton()
        {

        }

        public static IUserQueryService Instance
        {
            get
            {
                if( instance == null)
                {

                    instance= new UserQueryService();


                }return instance;
            }







        }










    }
}
