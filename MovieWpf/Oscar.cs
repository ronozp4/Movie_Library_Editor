//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieWpf
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oscar
    {
        public int Year { get; set; }
        public Nullable<int> ActorId_Id { get; set; }
        public Nullable<int> ActressId_Id { get; set; }
        public Nullable<int> DirectorId_Id { get; set; }
        public Nullable<int> MovieId_MovieSerial { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual Actress Actress { get; set; }
        public virtual Director Director { get; set; }
        public virtual Movy Movy { get; set; }
    }
}
