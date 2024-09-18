using DTO;

namespace Interfaces;

public interface IPaginationUtil
{
    PaginationDTO<T> GetPagination<T>(List<T> data, int page, int recordsPerPage) where T : class;
}