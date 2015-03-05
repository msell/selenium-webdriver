using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace demo
{
    public class describe_user_registration
    {
        public class when_user_enters_invalid_email
        {
            It should_display_email_error;                        
        }

        public class when_user_enters_valid_email
        {
            It should_not_display_email_error;
        }
        
        static string url = "http://quickstart-frontend.herokuapp.com/";
    }
}
