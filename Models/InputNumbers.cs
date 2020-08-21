using System;
using System.ComponentModel.DataAnnotations;

namespace webApp1.Models
{
    public class InputNumbers
    {
        [Required]
        [Display(Name ="First Number")]
        public long firstNum { get; set; }

        [Required]
        [Display(Name = "Second Number")]
        public long secondNum { get; set; }

    }
}
