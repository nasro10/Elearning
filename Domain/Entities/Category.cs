using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Category Description")]
        public string CategoryDescription { get; set; }

        //navigation properties
        virtual public ICollection<Book> Books { get; set; }

    }
}
