using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTaskLibrary.Models
{
    public class TodoTasksListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsArchived { get; set; }
        public string Colour { get; set; }
        public string Privacy { get; set; }

    }
}
