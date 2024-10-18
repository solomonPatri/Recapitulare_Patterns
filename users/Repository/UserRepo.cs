﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Repository
{
    public class UserRepo: IUserRepo
    {

        List<User> _users;
        string _filepath;

        public UserRepo()
        {
            _users = new List<User>();
            _filepath = GetDirectory();

            this.load();


        }
         
        public void load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filepath))
                {
                    string line = " ";
                    while ((line = sr.ReadLine()) != null)
                    {

                        switch (line.Split(",")[0])
                        {

                            case "User":
                                User user = new User(line);
                                this._users.Add(user);
                                break;
                            default:

                                break;



                        }






                    }


                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }

        private string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(currentDirectory, "data");
            string filepath = Path.Combine(dataFolder, "Users.txt");

            return filepath;


        }

       
        public IEnumerable<User> GetUsers()
        {

            return _users;
          
        }

        public int GeneratenextId()
        {
            Random random = new Random();
            int nrradnom = random.Next(100, 1000);

            return nrradnom;





        }

        public User FindUserByUsername(string username)
        {
            foreach (var user in _users)
            {
                if (user.Username.Equals(username))
                {
                    return user;
                }


            }

            return null;


        }

        public User FindUserById(int id)
        {

            foreach(var list in _users)
            {
                if (list.Id.Equals(id)){

                    return list;
                }
                

            }

            return null;



        }

        public User AddUser(User user)
        {
            user.Id = GeneratenextId();
           
            this._users.Add(user);

            return user;


        }
        public User DeleteUser(int id)
        {
            User user= this.FindUserById(id);
            this._users.Remove(user);
            return user;
        }


        
        public User UpdateUser( User user)
        {

           User editableUser=this.FindUserById(user.Id);


            if (user.Username != null)
            {
               editableUser.Username = user.Username;
            }

            if(user.Password != null)
            {
                editableUser.Password = user.Password;
            }

            if(user.Type != null)
            {
                editableUser.Type = user.Type;
            }


            return editableUser;

        }

    }
}
