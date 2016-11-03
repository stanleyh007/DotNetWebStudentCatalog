using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetWebStudentCatalog.Models.Entity
{
    public class StudentModel
    {
        public int StudentModelId { set; get; }

        [Required(ErrorMessage = "YEAH! -1 point!")]
        [MinLength(2, ErrorMessage ="You need more than 2 characters")]
        [DataType(DataType.Text)]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "YEAH! -2 point!")]
        //[RegularExpression(@"^[0-9]",ErrorMessage ="Number is not allowed")]
        public string LastName { set; get; }

        /*[Required(ErrorMessage = "YEAH! YOU DEAD xD!")]
        [EmailAddress(ErrorMessage = "Type a correct E-mail address!")]
        public string Email { set; get; }*/

        [Required]
        [Phone(ErrorMessage = "Do you really think this is a phonenumber?")]
        public string Phone { set; get; }
    }
}