namespace Tomers.WPF.DataVirtualization.Data
{
    public interface ICacheItemRefreshAction
    {
        void Refresh(string removedKey, object expiredValue);
    }
}
