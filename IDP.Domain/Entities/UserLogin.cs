namespace IDP.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
 
    public class UserLogin: IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Provider { get; set; }

        [MaxLength(200)]
        [Required]
        public string ProviderIdentityKey { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}
