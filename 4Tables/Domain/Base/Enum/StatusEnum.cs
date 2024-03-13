using System.ComponentModel.DataAnnotations;

namespace _4Tables.Domain.Base.Enum
{
    public enum StatusEnum
    {
        [Display(Name = "Pendente")]
        WAITING = 0,

        [Display(Name = "Progresso")]
        PROGRESS = 1,

        [Display(Name = "Finalizado")]
        DONE = 2,
    }
}
