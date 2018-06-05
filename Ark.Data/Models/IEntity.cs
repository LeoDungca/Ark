using System;
using System.Collections.Generic;
using System.Text;

namespace Ark.Data.Models
{
    public interface IEntity
    {
        int Id { get; set; }

        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> UpdatedBy { get; set; }
        Nullable<System.DateTime> UpdatedDate { get; set; }

    }
}
