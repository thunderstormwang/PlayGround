using System.Threading.Tasks;

namespace Utility
{
    public class DeadlockHelper
    {
        public async Task<int> GetRemoteData()
        {
            await Task.Delay(2 * 1000).ConfigureAwait(false);
            var result = 32767;

            return result;
        }
    }
}