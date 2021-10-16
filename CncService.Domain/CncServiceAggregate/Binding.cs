using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CncService.Domain.CncServiceAggregate
{
    // value object 
    [Table("endpoint")]
    public class Binding
    {
        public int id { get; set; }
        public double openTimeout { get; set; }
        public double closeTimeout { get; set; }
        public double sendTimeout { get; set; }
        public double receiveTimeout { get;  set; }
        public string bindType { get;  set; }
        public Binding(double openTimeout,double closeTimeout,double sendTimeout,double receiveTimeout,
            string bindType)
        {
            this.openTimeout = openTimeout;
            this.closeTimeout = closeTimeout;
            this.sendTimeout = sendTimeout;
            this.receiveTimeout = receiveTimeout;
            this.bindType = bindType;
        }

        public Binding() { }

        
        
    }
}
