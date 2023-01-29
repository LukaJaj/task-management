using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_management_system.Models
{ 
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("task_id")]
        public string Id { get; set; }

        [Required]
        [Column("title", TypeName = "varchar(256)")]
        public string? Title { get; set; }

        [Column("short_description", TypeName = "varchar(256)")]
        public string ShortDescription { get; set; }

        [Column("description", TypeName = "varchar(2048)")]
        public string Description { get; set; }

        [Column("attached_files", TypeName = "text")] //it should be converted as base64 string
        public string AttachedFiles { get; set; }
        
        [Required]
        [Column("assigned_to", TypeName = "text")]
        public string AssignedTo { get; set; }
        
        [Required]
        [NotMapped]
        public string UserId { get; set; }

    }
}