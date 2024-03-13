using System.ComponentModel.DataAnnotations;

namespace _4Tables.Domain.Base.Enum
{
    public enum CategoryEnum
    {
        [Display(Name = "Drinks")]
        DRINKS = 0,

        [Display(Name = "Bebidas")]
        BEVERAGER = 1,

        [Display(Name = "Prato Principal")]
        MAIN_COURSE = 2,

        [Display(Name = "Prato Entrada")]
        STARTES = 3,

        [Display(Name = "Saldas")]
        SALADS = 4,

        [Display(Name = "Sanduíches")]
        SANDWICHES = 5,

        [Display(Name = "Pizzas")]
        PIZZAS = 6,

        [Display(Name = "Vegetarianos")]
        VEGETA = 7,

        [Display(Name = "Bebidas Alcoólicas")]
        ALCOHOLIC_DRINKS = 8,

        [Display(Name = "Espetinho")]
        MEAT_SKEWERS = 9,

        [Display(Name = "Porções")]
        PORTION = 10,
    }
}
