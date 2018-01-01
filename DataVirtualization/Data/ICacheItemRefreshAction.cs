namespace DataVirtualization
{
    public interface ICacheItemRefreshAction
    {
        void Refresh(string removedKey, object expiredValue);
    }
}
