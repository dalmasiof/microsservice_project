using MessageBus;
using System.ComponentModel.DataAnnotations;

namespace UserService.Model
{
    public class UserDTO
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string  Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string  LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }



    }
}
