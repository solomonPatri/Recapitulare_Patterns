using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public interface IUserCommandService
    {
        
         User Add(User user);
         User Delete(int  id);

         User UpdateUser(User user);




    }
}
