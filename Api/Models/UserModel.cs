using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Node_id { get; set; }
        public string Avatar_url { get; set; }
    }
}
