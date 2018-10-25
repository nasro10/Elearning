using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [DisplayName("Image")]
        public string Image { get; set; }
        public string Fichier { get; set; }
        //foreign Key properties
        public int? CategoryId { get; set; }

        //navigation properties
        [ForeignKey("CategoryId ")]      //useless in this case   
        public virtual Category Category { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
