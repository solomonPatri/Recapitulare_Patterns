using Recapitulare_Patterns.users;
using Recapitulare_Patterns.users.exceptions;
using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Services;

namespace Recapitulare_Patterns
{
    public class View
    {
        private IUserCommandService _servicecomand;
        private IUserQueryService _servicequery;

        public View()
        {

            this._servicecomand = UserFactory.CreateUserService<IUserCommandService>();
            this._servicequery = UserFactory.CreateUserService<IUserQueryService>();




        }

        public void Meniu()
        {
            Console.WriteLine("1-> Afisare Users" + "\n");
            Console.WriteLine("2->Adaugare unui User" + "\n");
            Console.WriteLine("3-> Stergerea unui user:" + "\n");
            Console.WriteLine("4->Modificarea unui user:" + "\n");



        }

        public void play()
        {
            bool run = true;

            while (run)
            {
                Meniu();
                int nrales = int.Parse(Console.ReadLine());
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
            Console.WriteLine("Ce doriti sa adaugati :" + "\n");
            Console.WriteLine("1-> Angajat" + "\n" + "2-> CLient" + "\n");

            int nr = int.Parse(Console.ReadLine());

            switch (nr)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password");
                        string pass = Console.ReadLine();
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Salariul: ");
                        float sal = float.Parse(Console.ReadLine());
                        Console.WriteLine("Tipul de serviciu: ");
                        string typeserv = Console.ReadLine();

                        Angajat newang = Angajat.AngajatBuilder
                            .Create()
                            .SetId(_servicequery.GeneratenextId())
                            .SetUsername(username)
                            .SetPassword(pass)
                            .SetnameAngajat(name)
                            .SetSalariuAnfajat(sal)
                            .SetServiciePerson(typeserv)
                            .Build();

                        _servicecomand.Add(newang);
                       }catch(UserAlreadyExistException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                      
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Username:");
                        string userna = Console.ReadLine();
                        Console.WriteLine("Password");
                        string password = Console.ReadLine();
                        Console.WriteLine("Name: ");
                        string names = Console.ReadLine();
                        Console.WriteLine("Varsta: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Adresa: ");
                        string adress = Console.ReadLine();


                        Client newcl = Client.ClientBuilder
                            .Create()
                            .SetId(_servicequery.GeneratenextId())
                            .SetUsername(userna)
                            .SetPassword(password)
                            .SetNamePerson(names)
                            .SetAgePerson(age)
                            .SetAdressPerson(adress)
                            .Build();

                        _servicecomand.Add(newcl);


                    }catch(UserAlreadyExistException es)
                    {
                        Console.WriteLine(es.Message);
                    }









                    break;
            }










        }

        public void DeleteUser()
        {
            Console.WriteLine("Introduceti numele userului care doriti sa stergeti:" + "\n");
            string name = Console.ReadLine();

            try
            { 
                User user = _servicequery.ReturnByUsername(name);

                _servicecomand.Delete(user.Id);




            }
            catch (UserNotFoundException not)
            {
                Console.WriteLine(not.Message);


            }


        }





        public void Update()
        {
            Console.WriteLine("Introduceti userul care doriti sa modificati: " + "\n");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();

          

            try
            {
                User update = _servicequery.ReturnByUsername(username);

                _servicecomand.UpdateUser(update);



            }catch(UserNotUpdateException up)
            {
                Console.WriteLine(up.Message);
            }
            catch(UserNotFoundException not)
            {
                Console.WriteLine(not.Message);
            }





        }












    }

}
