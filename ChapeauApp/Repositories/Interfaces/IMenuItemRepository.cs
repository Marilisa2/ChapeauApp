using ChapeauApp.Models;

//tijdelijke repository
namespace ChapeauApp.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        MenuItem GetMenuItemById(int id);
    }
}
