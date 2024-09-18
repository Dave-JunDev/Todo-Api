namespace DTO;

public class PaginationDTO<T> where T : class
{
    public List<T>? Data { get; set; }
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 10;
    public int TotalRecords { get; set; } = 10;
    public int TotalPages => (int)Math.Ceiling((decimal)TotalRecords / RecordsPerPage);
}