using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Repository
{
    public class UserRepoSingleton
    {




        private static IUserRepo instance = null;


        private UserRepoSingleton()
        {

        }

        public static IUserRepo Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new UserRepo();
                }
                return instance;

            }
        }


    }









}
