using SQLite;
namespace ParksGamification.Models
{
    [Table("Parks")]
    public class Park
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
