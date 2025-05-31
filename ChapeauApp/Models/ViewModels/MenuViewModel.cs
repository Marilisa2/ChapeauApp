namespace ChapeauApp.Models.ViewModels
{
    public class MenuViewModel
    {
        //public List<MenuItem> AllMenuItems{ get; set; }
        public Menu Menu  { get; set; }
        public MenuViewModel()
        {
            
        }
        public MenuViewModel(Menu menu)
        {
            Menu = menu;
        }

        /*public MenuViewModel(List<MenuItem> allMenuItems)
        {
            AllMenuItems = allMenuItems;
        }*/
    }
}
