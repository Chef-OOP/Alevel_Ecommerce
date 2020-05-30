using System.Collections.Generic;

namespace ECommerce_Entity.Concrete.POCO
{
    /// <summary>
    /// JWT altyapısı için Core katmanında Oluşturulan Roles Tablosu
    /// </summary>
    public class OperationClaims 
        : BaseEntity
    {
        //TODO : Genişetilecek
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
