using Recapitulare_Patterns.users.exceptions;
using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public class UserComandService : IUserCommandService
    {

        IUserRepo _repo;
        public UserComandService()
        {
            this._repo = UserFactory.CreateUserService<IUserRepo>();

        }

        public User Add(User user)
        {
            User  searchedUser=this._repo.FindUserByUsername(user.Username);
            if (searchedUser==null)
            {
                if (user is Client)
                {
                    Client client = user as Client;


                    if (client.Username.Equals(user.Username))
                    {
                         this._repo.AddUser(client);
                        throw new UserSuccesAddException();
                    }
                    
                }
                if (user is Angajat)
                {
                    Angajat ang = user as Angajat;
                    if (ang.Username.Equals(user.Username))
                    {
                       this._repo.AddUser(ang);
                        throw new UserSuccesAddException();
                    }
                }
               

            }

            throw new UserUsernameEqualsException();


        }

        public User Delete(int id)
        {
            User finduser = this._repo.FindUserById(id);

            if (finduser != null)
            {
                this._repo.DeleteUser(id);
              

                throw new  UserSuccesDeleteException();


            }

            throw new UserNotFoundException();
        }

        public User UpdateUser(User user)
        {

            User update = this._repo.FindUserByUsername(user.Username);

            if (update != null)
            {

                if(user is Client)
                {
                    Client client = user as Client;


                    if (client.Username.Equals(user.Username))
                    {
                        throw new UserNotUpdateException();
                    }
                }
                if(user is Angajat)
                {
                    Angajat ang = user as Angajat;
                    if (ang.Username.Equals(user.Username))
                    {
                        throw new UserNotUpdateException();
                    }
                }


                this._repo.UpdateUser(update);

                return update;

            }
            throw new UserNotFoundException();



        }




    }
}
