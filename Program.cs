using Recapitulare_Patterns;
using Recapitulare_Patterns.users;
using Recapitulare_Patterns.users.models;
using Recapitulare_Patterns.users.Repository;
using Recapitulare_Patterns.users.Services;

internal class Program
{
    private static void Main(string[] args)
    {

        IUserRepo repo = new UserRepo();
       
        IUserCommandService comad = new UserComandService(repo);
        IUserQueryService queryService = new UserQueryService(repo);

        View view = new View(queryService,comad);

        view.play();
        
        









    }
}