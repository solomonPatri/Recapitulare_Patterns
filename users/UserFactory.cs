using Recapitulare_Patterns.users.Repository;
using Recapitulare_Patterns.users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users
{
    public class UserFactory
    {
        public static T CreateUserService<T>()
        {
            if (typeof(T) == typeof(IUserCommandService))
            {

                return (T)(object)UserCommandSingleton.Instance;

            }
               else if (typeof(T) == typeof(IUserQueryService))
              {
                return (T)(object)UserQuerySingleton.Instance;
              }


            else if (typeof(T) == typeof(IUserRepo))
            {
                return (T)(object)UserRepoSingleton.Instance;
            }
            else
            {
                throw new ArgumentException("No service found for the given type");
            }
        
            }
        
    }






}       
 


