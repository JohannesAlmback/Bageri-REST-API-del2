using System.ComponentModel.DataAnnotations;

namespace Mormor_Dagnys_Bageri_REST_API.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
