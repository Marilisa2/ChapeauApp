namespace ChapeauApp.Models.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItem> AllMenuItems{ get; set; }
        public MenuViewModel()
        {
            
        }

        public MenuViewModel(List<MenuItem> allMenuItems)
        {
            AllMenuItems = allMenuItems;
        }
    }
}
