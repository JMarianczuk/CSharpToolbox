using System;

namespace CSharpToolbox.Operation
{
    public class Processing
    {
        public static Action ProcessEvents(Action processSingleEvent, Action doBeforeFirstEvent, Action doBetweenEvents)
        {
            int processed = 0;
            return () =>
            {
                if (processed == 0)
                {
                    doBeforeFirstEvent();
                }
                else
                {
                    doBetweenEvents();
                }
                processed += 1;
                processSingleEvent();
            };
        }

        public static Action<TElement> ProcessResults<TElement>(Action<TElement> processSingleResult, Action doBeforeFirstResult, Action doBetweenResults)
        {
            int processed = 0;
            return element =>
            {
                if (processed == 0)
                {
                    doBeforeFirstResult();
                }
                else
                {
                    doBetweenResults();
                }
                processed += 1;
                processSingleResult(element);
            };
        }
    }
}