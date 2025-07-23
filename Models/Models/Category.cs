using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Category
    {
        #region Properties

        // [Key] // --> Configured via Fluent API
        public int Id { get; set; }

        // [Required]
        // [MaxLength(50)]
        public string catName { get; set; }

        // [Required]
        public int catOrder { get; set; }

        // [NotMapped]
        public DateTime createdDate { get; set; }

        // [Column("isDeleted")]
        public bool markedAsDeleted { get; set; }

        #endregion
    }
}
