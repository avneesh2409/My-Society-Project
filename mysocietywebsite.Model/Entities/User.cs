using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace mysocietywebsite.Model.Entities
{
    public class User : BaseEntity
    {
        public string Fullname { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
    }
}
