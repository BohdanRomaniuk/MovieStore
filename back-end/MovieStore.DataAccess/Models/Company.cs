using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStore.DataAccess
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<MovieCompany> Movies { get; set; }
    }
}
