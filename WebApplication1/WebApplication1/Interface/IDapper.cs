using System.Collections.Generic;

namespace WebApplication1.Interface
{
    public interface IDapper
    {
        IEnumerable<T> Query<T>(string connection, string sql, object parameter = null);
    }
}
