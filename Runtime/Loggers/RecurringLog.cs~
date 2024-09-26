using System;

namespace Francespo.Loggers
{
    public class RecurringLog
    {
        public Func<bool> logCondition;
        public Action logAction;


        public RecurringLog(Func<bool> logCondition, Action logAction)
        {
            this.logCondition = logCondition;
            this.logAction = logAction;
        }


        public void LogIfCondition()
        {
            if (logCondition())
            {
                logAction();
            }
        }
    }
}