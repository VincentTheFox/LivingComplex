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
    
    public partial class Employers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employers()
        {
            this.News = new HashSet<News>();
        }
    
        public int idEmployee { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public System.DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime WorkingStartDate { get; set; }
        public int EmployeePostID { get; set; }
        public int RateFactorID { get; set; }
        public long INN { get; set; }
        public long SNILS { get; set; }
        public int PassportSerial { get; set; }
        public int PassportNumber { get; set; }
        public string ContractNumber { get; set; }
    
        public virtual EmployeePost EmployeePost { get; set; }
        public virtual Gender Gender1 { get; set; }
        public virtual RateFactor RateFactor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
    }
}