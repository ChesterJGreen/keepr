using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
       public int Id { get; set; } 
       [Required]
       [MaxLength(30)]
       public string Name { get; set; }
       [Required]
       [MaxLength(250)]
       public string Description { get; set; }
       [MaxLength(250)]
       public string Img { get; set; }
       public string CreatorId { get; set; }
       public int Views { get; set; }
       public int Shares { get; set; }
       public int Keeps { get; set; }
       public Profile Creator { get; set; }
    }
     
}