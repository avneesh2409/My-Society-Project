using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace mysocietywebsite.Model.Entities
{
    public class Gallery:BaseEntity
    {
        public string Name { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
    }
}
