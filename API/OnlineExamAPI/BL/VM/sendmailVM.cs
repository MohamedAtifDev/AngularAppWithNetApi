using System.ComponentModel.DataAnnotations;

namespace OnlineExamAPI.BL.VM
{
    public class sendmailVM
    {
        [Required(ErrorMessage ="email is required")]
     
        public string mail { get; set; }
        [Required(ErrorMessage = "message is required")]
        [MinLength(10,ErrorMessage ="min length is 10 characters")]
        public string message { get; set; }
    }
}
