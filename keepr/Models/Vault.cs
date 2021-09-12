using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace keepr.Models
{
  public class Vault
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public bool? IsPrivate { get; set; }
        public string CreatorId { get; set; }        
        public Profile Creator { get; set; }
        public string Img { get; set; }

        public virtual ICollection<VaultKeep> VaultKeeps { get; set; }

    }
}