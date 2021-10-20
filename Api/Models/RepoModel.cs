using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class RepoModel
    {
        public int Id { get; set; }
        public string Node_id { get; set; }
        public string Name { get; set; }
        public string Full_name { get; set; }
        public bool Private { get; set; }
        public UserModel Owner { get; set; }
        public string Description { get; set; }

    }
}
