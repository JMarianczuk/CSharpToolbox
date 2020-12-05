using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MoreLinq;

namespace CSharpToolbox.Extensions
{
    public static class CancellationTokenExtensions
    {
        public static CancellationToken AddTimeout(this CancellationToken token, TimeSpan timeout)
        {
            var timeoutSource = new CancellationTokenSource();
            token.Register(timeoutSource.Cancel);
            if (token.IsCancellationRequested)
            {
                timeoutSource.Cancel();
                return timeoutSource.Token;
            }
            timeoutSource.CancelAfter(timeout);
            return timeoutSource.Token;
        }

        public static CancellationToken CombineWith(this CancellationToken token, params CancellationToken[] tokens)
        {
            var combinedTokenSource = new CancellationTokenSource();
            token.Register(combinedTokenSource.Cancel);
            tokens.ForEach(t => t.Register(combinedTokenSource.Cancel));
            if (token.IsCancellationRequested || tokens.Any(t => t.IsCancellationRequested))
            {
                combinedTokenSource.Cancel();
            }
            return combinedTokenSource.Token;
        }
    }
}
