using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CncService.Domain.CncServiceAggregate
{
    // entity
    [Table("capability")]
    public class Capability
    {
        public string id { get; set; }
        public string name { get; set; }
        public string input { get; set; }
        public string output { get; set; }
        
        public int endpointId { get; set; }

        public Capability(string name, string input, string output)
        {
            id = Guid.NewGuid().ToString();
            this.name = name;
            this.input = input;
            this.output = output;
        }

        public Capability()
        {

        }

        public void Update(string name, string input, string output)
        {
            this.name = name;
            this.input = input;
            this.output = output;
        }
        
    }
}
