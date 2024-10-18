using Recapitulare_Patterns;
using Recapitulare_Patterns.users;
using Recapitulare_Patterns.users.Repository;
using Recapitulare_Patterns.users.Services;

internal class Program
{
    private static void Main(string[] args)
    {

        IUserRepo repo = new UserRepo();
        IUserCommandService cmdrep = new UserComandService(repo);
        IUserQueryService rep = new UserQueryService(repo);

        View view = new View(rep,cmdrep);

           view.play();

      //  User user = User.UserBuilder
         //   .Create()
         ////  .Id(2)
         // .Username("username")
         //   .Password("password")
         //   .Type("Client")
         // .Build();




      







    }
}