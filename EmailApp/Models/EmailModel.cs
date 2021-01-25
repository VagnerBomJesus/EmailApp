using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApp.Models
{
    public class EmailModel
    {
        private const string sms = "Por favor digite um email válido";
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        //public IFormFile Attachment { get; set; }
        [Required(ErrorMessage = sms)]
        [EmailAddress(ErrorMessage = sms)]
        [Display(Name = "Email *", Prompt = "Inserir um Email")]
        public string FromEmail { get; set; }//this you can configure in appsetting

        public string FromPassword { get; set; }//this you can configure in appsetting
    }
}
