using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("categories")]
    public class Category : BaseEntity
    {
***REMOVED***public string Name { get; set; }
    }
}