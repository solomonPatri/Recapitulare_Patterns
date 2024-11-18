using Microsoft.VisualBasic;
using Recapitulare_Patterns;
using Recapitulare_Patterns.system;
using Recapitulare_Patterns.users;
using Recapitulare_Patterns.users.exceptions;
using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Repository;
using Recapitulare_Patterns.users.Services;

internal class Program
{
    private static void Main(string[] args)
    {


        // IUserCommandService userService = UserFactory.CreateUserService<IUserCommandService>();


        //  userService.Delete(1232112);
        // View v = new View();
        // v.play();
        //Client user = Client.ClientBuilder
        //  .Create()
        //  .SetId(4)
        //  .SetUsername("marcos@yahoo.com")
        //  .SetAgePerson(29)
        //  .Build();



        //UserComandService sv = new UserComandService();
        //try
        //{

        //    sv.UpdateUser(user);

        //}
        //catch (UserNotUpdateException not)
        //{
        //    Console.WriteLine(not.Message);
        //}
        //catch (UserNotFoundException n)
        //{
        //    Console.WriteLine(n.Message);
        //}




        //UserQueryService q = new UserQueryService();

        //try
        //{

        //    q.ReturnByUsername("maria23@yahoo.com");

        //}
        //catch (UserNotFoundException not)
        //{
        //    Console.WriteLine(not.Message);
        //}
        //catch ( UserNotUpdateException n)
        //{
        //    Console.WriteLine(n.Message);
        //}


        ////////Imi afiseaza Doesnt exist dar pentru update as dori daca exista sa afiseze ca nu se poate mofica   !!!!??????
        View v = new View();
         v.play();
     

       





        

     




    }
}