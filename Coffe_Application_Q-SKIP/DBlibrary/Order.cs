//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBlibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int order_number { get; set; }
        public int coffee_ID { get; set; }
        public System.TimeSpan collection_time { get; set; }
        public System.DateTime order_date { get; set; }
        public int user_ID { get; set; }
    
        public virtual CoffeeOrder Coffee { get; set; }
        public virtual User User { get; set; }
    }
}
