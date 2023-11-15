using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities.Models
{
    public class RegisterViewModels
    {
        // data annotation
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string RePassword { get; set; }
    }
}
