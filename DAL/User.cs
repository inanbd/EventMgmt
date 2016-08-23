using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CustomAttr;

namespace DAL
{
    public class User
    {
        [Key]
        public int UserId { set; get; }


        [Display(Name = "Username")]
        [UsernameNotExists]
        [Required(ErrorMessage = "Username Required")]
        public string UserName { set; get; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        public string FirstName { set; get; }



        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { set; get; }



        [RegularExpression(@"admin|customer", ErrorMessage =
            "user type has to be 'admin' / 'customer'")]
       // [Required(ErrorMessage ="Usertype is Required ('admin' / 'customer')")]
        public string UserType { set; get; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Name is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [MailNotExists]
        public string Email { set; get; }


        [Required(ErrorMessage ="Address Required")]
        public string Address { set; get; }


        [Display(Name = "Contact Number")]
        [Required(ErrorMessage ="Contact Number Required")]
        [StringLength(14,MinimumLength =8,ErrorMessage ="Contact Number have to be 8-14 charecters")]
        public string ContactNumber { set; get; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength=5,ErrorMessage ="5-20 char required")]
        public string Password { set; get; }



        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not matched")]
        public string ConfirmPassword { set; get; }


        public List<Event> Events { set; get; }


    }
}
