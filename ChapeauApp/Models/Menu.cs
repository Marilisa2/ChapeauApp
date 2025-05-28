using ChapeauApp.Enums;
namespace ChapeauApp.Models
{
    public class Menu
    {
        //public int MenuId { get; set; }
        //public string MenuName { get; set; }
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

        /*public Menu(List<MenuItem> menuItems)
        {
            MenuItems = menuItems;
        }
        public Menu(int menuId, string menuName)
        {
           MenuId = menuId;
           MenuName = menuName;
        }
        public Menu(int menuId, string menuName, List<MenuItem> menuItems)
        {
           MenuId = menuId;
           MenuName = menuName;
           MenuItems = menuItems;
        }*/
    }
}
