using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ha.appointment.Models.Model
{
    public class ResetPassword
    {
   
        
        public string CurrentPassword { get; set; }

       
        public string NewPassword { get; set; }
    }
}
