using System.ComponentModel.DataAnnotations;
namespace TFSPraise.Entities
{
    public class Employee
    {
        public string Name { get; set; }
        [Key]
        public string ID { get; set; }
        public bool ResignFlag { get; set; }
    }
}