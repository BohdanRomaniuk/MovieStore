﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.DataAccess
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UkrName { get; set; }

        [Required]
        public string OriginName { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Story { get; set; }
    }
}
