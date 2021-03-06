﻿using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class ResetPasswordModel : BaseModel
    {
        [Required]
        public string Token { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}