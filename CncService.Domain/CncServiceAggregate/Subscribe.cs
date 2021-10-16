using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CncService.Domain.CncServiceAggregate
{
    [Table("subscriber")]
    public class Subscribe
    {
        public int id { get; set; }
        public string serviceid { get; set; }
        public string subid { get; set; }

        public Subscribe(string serviceid, string subid)
        {
            this.serviceid = serviceid;
            this.subid = subid;
        }
    }
}
