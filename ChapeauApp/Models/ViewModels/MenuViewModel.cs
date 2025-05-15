namespace ChapeauApp.Models.ViewModels
{
    public class MenuViewModel
    {
        public string MenuName { get; set; }
        public List<MenuItem> MenuItems{ get; set; }
        public MenuViewModel()
        {
            
        }

        public MenuViewModel(string menuName, List<MenuItem> menuItems)
        {
            MenuName = menuName;
            MenuItems = menuItems;
        }
    }
}
