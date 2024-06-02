using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenas.Models
{
    public class ListaPaginada<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPage { get; private set; }
        public string SearchString { get; private set; }

        public ListaPaginada(List<T> items, int count, int pageIndex, int pageSize, string searchString)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (decimal)pageSize);
            SearchString = searchString;
            AddRange(items);
        }

        public bool hasPreviousPage => (PageIndex > 1);
        public bool hasNextPage => (PageIndex < TotalPage);
    }
}
