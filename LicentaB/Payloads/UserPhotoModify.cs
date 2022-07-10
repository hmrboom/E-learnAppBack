using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class UserPhotoModify
    {
        public Guid? Id { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
