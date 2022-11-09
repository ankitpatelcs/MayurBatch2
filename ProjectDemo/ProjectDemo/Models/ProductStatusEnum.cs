using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public enum ProductStatusEnum
    {
        Pending = 1,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
}