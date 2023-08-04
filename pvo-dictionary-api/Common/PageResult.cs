namespace ThucTapQuanLyPhatTu.Common
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }

        public PagedResult(List<T> data, int pageSize, int totalRecord)
        {
            Data = data;
            PageSize = pageSize;
            TotalRecord = totalRecord;
            TotalPage = (int)Math.Ceiling(totalRecord / (double)pageSize);
        }
    }
}
