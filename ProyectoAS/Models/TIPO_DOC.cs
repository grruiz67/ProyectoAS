//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIPO_DOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_DOC()
        {
            this.ESTUDIANTEs = new HashSet<ESTUDIANTE>();
        }
    
        public long ID_TIPO_DOC { get; set; }
        public string ABREVIATURA { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTUDIANTE> ESTUDIANTEs { get; set; }
    }
}
