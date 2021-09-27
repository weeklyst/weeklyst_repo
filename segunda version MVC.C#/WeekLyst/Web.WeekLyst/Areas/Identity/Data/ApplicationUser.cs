using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Web.WeekLyst.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Apellidos { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Documento { get; set; }
    }
}
