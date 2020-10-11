using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mysocietywebsite.Model.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
