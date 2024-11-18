using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recapitulare_Patterns.system;
using Recapitulare_Patterns.users.exceptions;
using Microsoft.VisualBasic;

namespace Recapitulare_Patterns.users.Services
{
    public  class UserQueryService:IUserQueryService
    {

        private IUserRepo _repo;

        public UserQueryService()
        {
            this._repo = UserFactory.CreateUserService<IUserRepo>();
        }

        public IEnumerable<User> GetAll()
        {
           return this._repo.GetUsers();
        }

        public User ReturnById(int id)
        {

            User user = this._repo.FindUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException();


            }
            return user;
        }

        public User ReturnByUsername(string username)
        {
            
           User user= this._repo.FindUserByUsername(username);

            if (user == null)
            {

                throw new UserNotFoundException();

               
            }

            return user;
        }

        public int GeneratenextId()
        {
            Random random = new Random();
            int nrradnom = random.Next(100, 1000);

            return nrradnom;





        }




    }
}
