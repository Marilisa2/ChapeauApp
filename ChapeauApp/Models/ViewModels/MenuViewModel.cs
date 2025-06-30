namespace ChapeauApp.Models.ViewModels
{
    public class MenuViewModel
    {
        public Menu Menu  { get; set; }
        public MenuViewModel()
        {
            
        }
        public MenuViewModel(Menu menu)
        {
            Menu = menu;
        }
    }
}
