﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Guitar.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="用户名不为空")]
        [MaxLength(8, ErrorMessage ="{0} 昵称不超过8个字符!")]
        public string User_name { get; set; }

        [Required]
        [StringLength(100,MinimumLength =6,ErrorMessage = "{0} 密码必须至少包含{2}个字符!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = " 密码和确认密码不匹配!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage ="邮箱地址格式不正确!")]
        public string Email { get; set; }
    }
}