using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.models
{
    public class Client : User
    {
        private string _name;
        private int _age;
        private string _address;

        public Client(string Propietati) : base(Propietati)
        {

            string[] text = Propietati.Split(',');

            _name = text[4];
            _age = int.Parse(text[5]);
            _address = text[6];

        }
        public Client()
        {
            this._name = null;
            this._age = 0;
            this._address = null;

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Adress
        {
            get { return _address; }
            set { _address = value; }
        }


        public override string ToString()
        {
            string t = " " + base.ToString();
           
            t += "Name: " + Name + "\n";
            t += "Varsta: " + Age + "\n";
            t += "Adresa:" + Adress + "\n";
            return t;

        }


        public int CompareTo(Client other)
        {
            if (_age > other._age)
            {
                return 1;
            }

            if (_age < other._age)
            {
                return -1;

            }

            return 0;

        }


        public override bool Equals(object client)
        {
            return client is Client other && Name.Equals(other.Name);
        }




        public class ClientBuilder
        {
            private readonly Client _person;

            public ClientBuilder(Client cl)
            {
                _person = cl;

            }
            public static ClientBuilder Create()
            {

                return new ClientBuilder(new Client());

            }
            public ClientBuilder SetNamePerson(string name)
            {
                _person.Name = name;
                return this;

            }
            public ClientBuilder SetAgePerson(int age)
            {
                _person.Age = age;

                return this;
            }

            public ClientBuilder SetAdressPerson(string adress)
            {

                _person.Adress = adress;

                return this;

            }

            public ClientBuilder SetId(int Id)
            {

                _person.Id = Id;
                return this;


            }
            public ClientBuilder SetUsername(string username)
            {
                (_person as User).Username = username;
                return this;

            }

            public ClientBuilder SetPassword(string password)
            {
                (_person as User).Password = password;
                return this;

            }

                public Client Build()
            {
                return _person;
            }




        }




    }
}
