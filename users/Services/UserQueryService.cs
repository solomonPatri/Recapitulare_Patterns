using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public  class UserQueryService:IUserQueryService
    {

        private IUserRepo _repo;

        public UserQueryService()
        {
            this._repo = UserRepoSingleton.Instance;
        }

        public IEnumerable<User> GetAll()
        {
           return this._repo.GetUsers();
        }

        public User ReturnById(int id)
        {

            return this._repo.FindUserById(id);


        }

        public User ReturnByUsername(string username)
        {
            
           return this._repo.FindUserByUsername(username);

        }

        public int GeneratenextId()
        {
            Random random = new Random();
            int nrradnom = random.Next(100, 1000);

            return nrradnom;





        }




    }
}
