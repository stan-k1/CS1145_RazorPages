using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS1145_RazorPages.Domain
{
    public class Actor
    {
        public int Id { get; set; }
        [Display(Name = "First Name")] public string FirstName { get; set; }
        [Display(Name = "Last Name")] public string LastName { get; set; }
        public List<Movie> Movies { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
