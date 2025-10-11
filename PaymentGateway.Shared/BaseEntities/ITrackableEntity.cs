using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Shared.BaseEntities
{
    public  interface ITrackableEntity
    {
        public int Id { get; set; }
        [DefaultValue(typeof(DateTime),"01/01/0001 00:00:00")]
        public DateTime Created { get; set; }
        [DefaultValue(typeof(DateTime), "01/01/0001 00:00:00")]
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
