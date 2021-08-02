using System;
using System.Threading;
using System.Threading.Tasks;

namespace Utility
{
    public class BlockHelper
    {
        public async Task<int> GetRemoteData()
        {
            var result = 0;

            await Task.Delay(2 * 1000);
            result = 32767;

            return result;
        }
    }
}