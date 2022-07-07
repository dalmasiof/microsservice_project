using MessageBus;
using System.ComponentModel.DataAnnotations;

namespace UserService.Model
{
    public class UserVM
    {
        public long id { get; set; }

        [Required]
        [MaxLength(500)]
        public string  name { get; set; }

        [Required]
        [MaxLength(500)]
        public string  lastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }

        [Required]
        [MaxLength(256)]
        public string email { get; set; }



    }
}
