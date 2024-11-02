using Recapitulare_Patterns.users;
using Recapitulare_Patterns.users.exceptions;
using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
             User user = _servicequery.ReturnByUsername(username);
           
            try
            {
              
                _servicecomand.Add(user);

            }catch(UserAlreadyExistException e)
            {
                Console.WriteLine(e.Message);

            }

           

        }

        public void DeleteUser()
        {

            
          

            int id = 123;
           
       
            try
            {




                _servicecomand.Delete(id);

            }catch(UserNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }





        }





        public void Update()
        {
            Console.WriteLine("Introduceti userul care doriti sa modificati: " + "\n");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            User user = _servicequery.ReturnByUsername(username);
            try
            {
                try
                {
                    _servicecomand.UpdateUser(user);

                }catch(UserNotUpdateException up)
                {
                    Console.WriteLine(up.Message);
                }


            }catch(UserNotFoundException not)
            {

                Console.WriteLine(not.Message);
            }

             



        }












    }

}
