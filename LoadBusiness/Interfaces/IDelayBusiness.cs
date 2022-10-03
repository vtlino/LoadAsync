namespace LoadBusiness.Interfaces
{
    public interface IDelayBusiness
    {
        Task DelayAsync();
        Task<int> DelayAsyncInt(int sequencyOrder);
        Task<int> DelayAsyncIntException(int sequencyOrder);
    }
}