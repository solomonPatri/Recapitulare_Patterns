using Recapitulare_Patterns.users;
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

        private IUserQueryService _servicequery;
        private IUserCommandService _servicecomand;

        public View(IUserQueryService userQueryService,IUserCommandService usercomand)
        {
            
            this._servicecomand= usercomand;
            this._servicequery = userQueryService;

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
            string username = Console.ReadLine(); Console.WriteLine("Type:" + "\n");
            string type = "User";
            Console.WriteLine("Password: ");
            string Password = Console.ReadLine();

            User newuser = User.UserBuilder
            .Create()
            .Username(username)
            .Password(Password)
            .Type(type)
            .Build();

            User user = _servicequery.ReturnByUsername(username);

            if(user.Username != username)
            {
                
                _servicecomand.Add(newuser);

            }
            else
            {
                Console.WriteLine("Deja exista acest user");
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
            
            if (user != null)
            {
                Console.WriteLine("Introduceti datele cele noi" + "\n");
                Console.WriteLine("Username:");
                string usernam = Console.ReadLine();
                Console.WriteLine("Parola: ");
                string parola = Console.ReadLine();
                Console.WriteLine("Type: Client/Angajat");
                string type = Console.ReadLine();

                User update = User.UserBuilder
                    .Create()
                    .Id(user.Id)
                    .Type(type)
                    .Username(usernam)
                    .Password(parola)
                    .Build();
                _servicecomand.UpdateUser(update);
            }
            else
            {
                Console.WriteLine("Nu exista userul pentru al modifica");
            }





        }


       
















    }

}
