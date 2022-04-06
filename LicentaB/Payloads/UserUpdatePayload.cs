using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class UserUpdatePayload
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
              
        public string First_Name { get; set; }
        
        public string Last_Name { get; set; }
        
        public bool Gender { get; set; }

        public string Phone { get; set; }
        public string UserName { get; set; }

    }
}
