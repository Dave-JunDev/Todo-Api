using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;
[Table("todo")]
public class TodoDTO
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string? Title { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("iscompleted")]
    public bool IsCompleted { get; set; }
}