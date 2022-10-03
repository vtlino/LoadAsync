using LoadBusiness.Interfaces;

namespace LoadBusiness
{
    public class DelayBusiness : IDelayBusiness
    {
        private readonly int _delayMs = 100;

        public DelayBusiness()
        {
            Task.Delay(_delayMs).Wait();
            Console.WriteLine($"Constructor passed here");
        }

        public async Task DelayAsync()
        {
            await Task.Delay(_delayMs);
        }

        public async Task<int> DelayAsyncInt(int sequencyOrder)
        {
            await DelayAsync();
            Console.WriteLine(sequencyOrder);
            return sequencyOrder;
        }

        public async Task<int> DelayAsyncIntException(int sequencyOrder)
        {
            await DelayAsync();
            throw new NullReferenceException();
        }
    }
}