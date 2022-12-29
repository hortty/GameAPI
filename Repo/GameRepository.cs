using GamesAPI.Context;
using GamesAPI.Model;

namespace GamesAPI.Repo
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(DataContext dataContext) : base(dataContext)
        {
            
        }
    }
}
