using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTaskLibrary.Models
{
    public class TodoTaskModel
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }   
        public int RegionId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; } = null;
        public Guid UserId { get; set; }
    }
}
