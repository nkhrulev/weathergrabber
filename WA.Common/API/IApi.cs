using WA.Common.DataLayer;

namespace WA.Common.API
{
    public interface IApi
    {
        void Bind(string host, int port, IStorage storage);
        
        void UnBind();
    }
}
