using System.ComponentModel.DataAnnotations;

namespace BlogApiDemo.DataAccesLayer
{
    public class Employe
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
