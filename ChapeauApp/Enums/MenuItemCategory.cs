using System.ComponentModel.DataAnnotations;

namespace ChapeauApp.Enums
{
    public enum MenuItemCategory
    {
        All, Voorgerecht, Tussengerecht, Hoofdgerecht, Nagerecht, [Display(Name = "Bieren van de tap")] Bieren, Wijnen, [Display(Name = "Koffie / Thee")] KoffieThee, [Display(Name = "Gedistilleerde drank")] GedistilleerdeDrank
    }
}