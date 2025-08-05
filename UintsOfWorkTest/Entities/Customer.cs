using Dapper;

namespace UintsOfWorkTest.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
