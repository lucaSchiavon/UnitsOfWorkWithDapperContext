using Dapper;

namespace UintsOfWorkTest.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
