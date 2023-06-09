﻿using System.ComponentModel.DataAnnotations;

namespace webbmvcapp.ViewModels;

public class UserLoginViewModel
{

    [Display(Name = "E-mail Adress")]
    [Required(ErrorMessage = "E-mail is required.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
