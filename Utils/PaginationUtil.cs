using DTO;
using Interfaces;

namespace Utils;

public class PaginationUtil : IPaginationUtil
{
    private static List<T> Paginate<T>(List<T> data, int page, int recordsPerPage)
    {
        return data.Skip((page - 1) * recordsPerPage).Take(recordsPerPage).ToList();
    }

    public PaginationDTO<T> GetPagination<T>(List<T> data, int page, int recordsPerPage) where T : class
    {
        return new PaginationDTO<T>
        {
            Data = Paginate(data, page, recordsPerPage),
            Page = page,
            RecordsPerPage = recordsPerPage,
            TotalRecords = data.Count,
        };
    }
}