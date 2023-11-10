using SQLite;

namespace MauiCRUD.Models
{
    [Table("Users")]
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }

        public DateTime Birthday { get; set; }

    }
}
