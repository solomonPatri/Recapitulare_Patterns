using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.models
{
    public class User : IComparable<User>
    {

        private int _id;
        private string _type;
        private string _username;
        private string _password;

        public User(string Propietati)
        {
            string[] text = Propietati.Split(',');
            _type = text[0];
            _id = int.Parse(text[1]);
            _username = text[2];
            _password = text[3];


        }


        public User()
        {

            this.Id= 0;
            this.Type = null;
            this.Username = null;
            this.Password = null;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public int CompareTo(User other)
        {
            if (_id > other._id)
            {
                return 1;
            }

            if (_id < other._id)
            {
                return -1;

            }

            return 0;

        }


        public class UserBuilder
        {
            private readonly User _user;

            private UserBuilder(User user)
            {
                _user = user;
            }
            public static UserBuilder Create()
            {

                return new UserBuilder(new User());


            }

            public UserBuilder Id(int id)
            {
                _user.Id = id;

                return this;

            }

            public UserBuilder Username(string username)
            {
                _user.Username = username;
                return this;
            }

            public UserBuilder Type(string type)
            {
                _user.Type = type;
                return this;
            }

            public UserBuilder Password(string password)
            {
                _user.Password = password;
                return this;
            }

            public User Build()
            {
                return _user;
            }






        }


        public virtual string ToString()
        {
            string t = " ";
            t += "Id" + +Id + "\n";
            t += "type: " + Type + "\n";
            t += "Username: " + Username + "\n";
            t += "Password:" + Password + "\n";
            return t;

        }


        public virtual bool Equals(object user)
        {
            return user is User other && Id.Equals(other.Id);
        }








    }
}
