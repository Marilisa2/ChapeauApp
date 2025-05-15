namespace ChapeauApp.Models
{
    public class Menu
    {
        int MenuId { get; set; }
        string MenuName { get; set; }
        
        public Menu()
        {
            
        }

        public Menu(int menuId, string menuName)
        {
            MenuId = menuId;
            MenuName = menuName;
        }
    }
}
