using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Recapitulare_Patterns.users.models.Client;

namespace Recapitulare_Patterns.users.models
{
    public class Angajat : User
    {

        
        private string _name;
        private float _salariu;
        private string _typeserv;

        public Angajat(string Propietati) : base(Propietati)
        {
            string[] text = Propietati.Split(',');
          
            _name = text[4];
            _salariu = float.Parse(text[5]);
            _typeserv = text[6];

        }
        public Angajat()
        {

            this.Name = null;
            this.Salariu = 0;
            this._typeserv = null;





        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Salariu
        {
            get { return _salariu; }
            set { _salariu = value; }
        }

        public string TypeServ
        {
            get { return _typeserv; }
            set { _typeserv = value; }
        }

        public override string ToString()
        {
            string t = " " + base.ToString();
            
            t += "Name: " + Name + "\n";
            t += "Salariul: " + Salariu + "\n";
            t += "Serviciul Cerut:" + TypeServ + "\n";
            return t;

        }

        public int CompareTo(Angajat other)
        {
            if (_salariu > other._salariu)
            {
                return 1;
            }

            if (_salariu < other._salariu)
            {
                return -1;

            }

            return 0;

        }


        public class AngajatBuilder
        {
            private readonly Angajat _angajat;

            public AngajatBuilder(Angajat ang)
            {
                _angajat = ang;

            }
            public static AngajatBuilder Create()
            {

                return new AngajatBuilder(new Angajat());

            }
            public AngajatBuilder SetnameAngajat(string name)
            {
                _angajat.Name = name;
                return this;

            }
            public AngajatBuilder SetSalariuAnfajat(float salariul)
            {
                _angajat.Salariu = salariul;

                return this;
            }

            public AngajatBuilder SetServiciePerson(string type)
            {

                _angajat.TypeServ = type;

                return this;

            }
            public AngajatBuilder SetUsername(string username)
            {
                (_angajat as User).Username = username;
                return this;

            }
            public AngajatBuilder SetId(int id)
            {
                (_angajat as User).Id = id;
                return this;
            }
            public AngajatBuilder SetPassword(string password)
            {
                (_angajat as User).Password = password;
                return this;

            }
            public Angajat Build()
            {
                return _angajat;
            }














        }


        public override bool Equals(object angajat)
        {
            return angajat is Angajat other && Name.Equals(other.Name);
        }







    }
}
