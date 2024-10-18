using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public interface IUserQueryService
    {


        IEnumerable<User> GetAll();

        User ReturnById(int id);

        User ReturnByUsername(string username);

        int GeneratenextId();




    }
}
