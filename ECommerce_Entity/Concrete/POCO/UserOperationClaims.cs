namespace ECommerce_Entity.Concrete.POCO
{
    /// <summary>
    /// JWT altyapısı için Core katmanında Oluşturulan Kullanıcı-Roles Many-To-Many ilişkisel Tablosu
    /// </summary>
    public class UserOperationClaims
    {
        //TODO : Genişetilecek many to many table
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int OperationClaimId { get; set; }
        public  OperationClaims OperationClaims { get; set; }
    }
}
