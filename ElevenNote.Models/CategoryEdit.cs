using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}
