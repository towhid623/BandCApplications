//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_BoardsandCommissions
    {
        public int BoardCommissionKey { get; set; }
        public string Board_or_Commission_Name { get; set; }
        public string ApplicationXML { get; set; }
        public string Description { get; set; }
        public string Default_Contact_Name { get; set; }
        public string Default_Email { get; set; }
        public string Default_Phone { get; set; }
        public string Default_Web { get; set; }
        public string Appointment_Type { get; set; }
        public string Authority { get; set; }
        public Nullable<decimal> TermLength { get; set; }
        public string Special_Requirements { get; set; }
        public string Staff_Contact { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
