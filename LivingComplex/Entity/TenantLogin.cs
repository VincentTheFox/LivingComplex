//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LivingComplex.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TenantLogin
    {
        public int idLogin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int FlatID { get; set; }
        public int RoleID { get; set; }
    
        public virtual Flats Flats { get; set; }
        public virtual Roles Roles { get; set; }
    }
}