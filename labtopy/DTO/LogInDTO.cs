﻿using System.ComponentModel.DataAnnotations;

namespace labtopy.DTO
{
    public class LogInDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
