using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace EatZilla.Models.CoreClasses
{
    public class Resturant
    {
        [Key]
        public int Rid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string type { get; set; }

       
       
        public int OrderID {  get; set; }
       
        public Resturant()
        {
            
        }
        public Resturant(int id,String name)
        {
            this.Rid = id;
            this.Name = name;
            
        }
        public Resturant(int id, String name,String type)
        {
            this.Rid = id;
            this.Name = name;
            this.type = type;

        }
    }
}
