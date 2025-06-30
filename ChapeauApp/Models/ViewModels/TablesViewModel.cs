namespace ChapeauApp.Models.ViewModels
{
    public class TablesViewModel
    {
        public List<TableViewModel> Tables { get; set; }
        public TablesViewModel()
        {
            
        }

        public TablesViewModel(List<TableViewModel> tables)
        {
            Tables = tables;
        }
    }
}
