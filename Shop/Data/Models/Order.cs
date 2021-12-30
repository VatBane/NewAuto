using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пустое поле")]
        public string firstName { get; set; }

        [Display(Name ="Фамилия")]
        [Required(ErrorMessage = "Пустое поле")]
        public string lastName { get; set; }

        [Display(Name = "Адресс")]
        [StringLength(20, MinimumLength =5, ErrorMessage = "Слишком длинный адресс")]
        [Required(ErrorMessage = "Пустое поле")]
        public string adress { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Пустое поле")]
        public string email { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Пустое поле")]
        public string phone { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
