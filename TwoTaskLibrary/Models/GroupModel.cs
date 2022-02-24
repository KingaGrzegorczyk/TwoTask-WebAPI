using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTaskLibrary.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
