namespace ChapeauApp.Models.ViewModels
{
    public class MenusViewModel
    {
        public List<MenuViewModel> Menus { get; set; }
        public MenusViewModel()
        {
            
        }

        public MenusViewModel(List<MenuViewModel> menus)
        {
            Menus = menus;
        }
    }
}
