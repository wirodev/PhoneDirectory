using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    internal class PhoneBookEntry
    {
        [Key]
        [Required] // Ensure PhoneNumber is required
        public string PhoneNumber { get; set; }
        [Required] // Ensure Name is required
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} | Number: {PhoneNumber} | Address: {Address}";
        }
    }

}