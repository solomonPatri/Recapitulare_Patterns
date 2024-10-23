using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Recapitulare_Patterns.users.models;

namespace Recapitulare_Patterns.users.Repository
{
    public interface IUserRepo
    {

        IEnumerable<User> GetUsers(); 

        User FindUserByUsername(string username);
        User FindUserById(int id);


        User  AddUser(User user);   
        User DeleteUser(int id);

        User UpdateUser(User user);










    }
}
