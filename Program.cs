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


        // userService.Delete(1232112);
        // View v = new View();
        //   v.play();
        User user = User.UserBuilder
            .Create()
           .Username("maria23@yahoo.com")
            .Build();



        UserComandService sv = new UserComandService();
        try
        {

            try
            {
                sv.UpdateUser(user);
            }
            catch (UserNotUpdateException up)
            {
                Console.WriteLine(up.Message);
            }
        }catch(UserNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        ////////Imi afiseaza Doesnt exist dar pentru update as dori daca exista sa afiseze ca nu se poate mofica   !!!!??????
        // /View v = new View();
        // v.play();





    }
}