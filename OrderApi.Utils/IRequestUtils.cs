using Microsoft.AspNetCore.Http;

namespace OrderApi.Utils
{
    public interface IRequestUtils
    {
        string GetClient(HttpRequest request);
    }
}