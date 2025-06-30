using ChapeauApp.Enums;
namespace ChapeauApp.Models
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; }
        public MenuItemCard MenuItemCard { get; set; }
        public MenuItemCategory Category { get; set; }

        public Menu()
        {

        }

        public Menu(List<MenuItem> menuItems, MenuItemCard menuItemCard, MenuItemCategory category)
        {
            MenuItems = menuItems;
            MenuItemCard = menuItemCard;
            Category = category;
        }
    }
}
