namespace ChapeauApp.Models.ViewModels
{
   //this model is outdated and unused.
    public class MenusViewModel
    {
        public List<Menu> Menus { get; set; }
        //TODO Function for filter that changes which Menus are included.
        public MenusViewModel()
        {
            
        }

        public MenusViewModel(List<Menu> menus)
        {
            Menus = menus;
        }
    }
}
