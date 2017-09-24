using System;

namespace Tbc.Common
{
    public static class Utils
    {
        public static void WrapWithLogAction(Action<string> logAction, Action actionToWrap, string actionToWrapName)
        {
            WrapWithLogFunc(logAction, () =>
            {
                actionToWrap.Invoke();
                return 0;
            }, actionToWrapName);
        }

        public static TResult WrapWithLogFunc<TResult>(Action<string> logAction, Func<TResult> actionToWrap,
            string actionToWrapName)
        {
            if (string.IsNullOrEmpty(actionToWrapName))
            {
                throw new ArgumentNullException(nameof(actionToWrap));
            }

            DateTime startedAt = DateTime.Now;
            long startedAtTicks = startedAt.Ticks;

            logAction.Invoke($"{actionToWrapName} - Start executing...");
            TResult result = actionToWrap.Invoke();

            long finishedAtTicks = DateTime.Now.Ticks;

            logAction.Invoke(
                $"{actionToWrapName} - Finished ({new TimeSpan(finishedAtTicks - startedAtTicks)})");

            return result;
        }
    }
}