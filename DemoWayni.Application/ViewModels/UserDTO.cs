using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Application.ViewModels
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(30, ErrorMessage = "El apellido no puede tener más de 30 caracteres")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El DNI es requerido")]
        [MaxLength(8, ErrorMessage = "El DNI no puede tener más de 8 caracteres")]
        public string Dni { get; set; } = null!;
    }
}
