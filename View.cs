using Recapitulare_Patterns.users;
using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns
{
    public class View
    {
        private IUserCommandService _servicecomand;
        private IUserQueryService _servicequery;

        public View()
        {
            
            this._servicecomand= UserFactory.CreateUserService<IUserCommandService>();
            this._servicequery = UserFactory.CreateUserService<IUserQueryService>();

            this.play();



        }
       
       public void Meniu()
        {
            Console.WriteLine("1-> Afisare Users"+"\n");
            Console.WriteLine("2->Adaugare unui User"+"\n");
            Console.WriteLine("3-> Stergerea unui user:" + "\n");
            Console.WriteLine("4->Modificarea unui user:" + "\n");



        }

        public void play()
        {
            bool run = true;

            while (run)
            {
                Meniu();
                int nrales= int.Parse(Console.ReadLine());
                switch (nrales)
                {
                    case 1:
                        Afisare();
                        break;
                    case 2:
                        AdaugareUser();
                        Console.WriteLine("\n");
                        Console.WriteLine("Userul sa adaugat cu succes");   
                        break;

                    case 3:
                        DeleteUser();
                        Console.WriteLine("\n");
                        Console.WriteLine("Userul sters cu succes");
                        

                        break;
                    case 4:
                        Update();
                        break;
                    default:
                        break;



                }




            }







        }

     

        public void Afisare()
        {
            foreach (var item in _servicequery.GetAll())
            {
                Console.WriteLine(item.ToString());

            }




        }

        public void AdaugareUser()
        {
            Console.WriteLine("Introduceti datele corespunzatoare:" + "\n");
            
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Type:");
            string type = Console.ReadLine();
            Console.WriteLine("Password: ");
            string Password = Console.ReadLine();

            User newuser = User.UserBuilder
            .Create()
            .Username(username)
            .Password(Password)
            .Type(type)
            .Build();

            User user = _servicequery.ReturnByUsername(username);

            if ((user as Client).Username != username && (user as Angajat).Username != (username))
            {
                if (user.Username != username)
                {

                    _servicecomand.Add(newuser);

                }
                else
                {
                    Console.WriteLine("Deja exista acest user");
                }
            }


           

        }

        public void DeleteUser()
        {

            Console.WriteLine("Introduceti datele corespunzatoare:" + "\n");
            
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();

            User user = _servicequery.ReturnByUsername(username);

            if (user != null)
            {
                _servicecomand.Delete(user.Id);
            }
            else
            {
                Console.WriteLine("Nu exista acest user");
            }





        }
        public void Update()
        {
            Console.WriteLine("Introduceti userul care doriti sa modificati: " + "\n");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();

            User user = _servicequery.ReturnByUsername(username);
            
            
             if ((user is Client) != null)
                {
                Console.WriteLine("Introduceti acuma noile date" + "\n");
                Console.WriteLine("Parola");
                string pass = Console.ReadLine();
                Console.WriteLine("Age:");
                int age = int.Parse(Console.ReadLine());

                    Client editableCl = Client.ClientBuilder
                        .Create()
                        .SetId(user.Id)
                        .SetUsername (username)
                        .SetPassword(pass)
                        .SetAgePerson(age)
                        .Build();
                    _servicecomand.UpdateUser(editableCl);

                    Console.WriteLine("Clientul sa modificat cu succes");

             }
             else
                {
                    if((user is Angajat)!=null) {

                    Console.WriteLine("Introduceti acuma noile date" + "\n");
                    Console.WriteLine("Parola");
                    string passw = Console.ReadLine();
                    Console.WriteLine("Salariul");
                        float salariul = float.Parse(Console.ReadLine());

                        Angajat editableAngajat = Angajat.AngajatBuilder
                            .Create()
                            .SetId(user.Id)
                            .SetUsername(username)
                            .SetPassword(passw)
                            .SetSalariuAnfajat(salariul)
                            .Build();
                        _servicecomand.UpdateUser(editableAngajat);
                        Console.WriteLine("Angajatul sa modificat cu succes");
                    
                    }



                
            }





        }












    }

}
