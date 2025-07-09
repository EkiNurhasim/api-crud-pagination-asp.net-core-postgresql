using System;

namespace Practice.Dtos;

public class Pageable<T>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public required IEnumerable<T> Data { get; set; }
                
}
