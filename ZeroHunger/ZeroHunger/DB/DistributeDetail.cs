//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DistributeDetail
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int DistributeRequestId { get; set; }
    
        public virtual DistributeRequest DistributeRequest { get; set; }
    }
}
