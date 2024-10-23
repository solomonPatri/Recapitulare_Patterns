using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public  class UserQuerySingleton
    {

        private static IUserQueryService _userQueryService = null;

        private UserQuerySingleton()
        {

        }

        public static IUserQueryService UserQueryService
        {
            get
            {
                if( _userQueryService == null)
                {

                    _userQueryService= new UserQueryService();


                }return _userQueryService;
            }







        }










    }
}
