using System;
using System.Collections.Generic;
using System.Text;

namespace Ark.Data.Models
{
    public class AuditLog : IEntity
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public long RecordId { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string Username { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
