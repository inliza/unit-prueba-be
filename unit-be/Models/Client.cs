using System;
namespace unit_be.Models
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public string[] phones { get; set; }
        public string sex { get; set; }
    }

}
