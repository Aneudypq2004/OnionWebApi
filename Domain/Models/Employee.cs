using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        [Column("EmployeeID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Employee Name is a required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Employee Age is a required field")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Position  is a required field")]

        public Position? Position { get; set; }


        [ForeignKey(nameof (Company))]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
