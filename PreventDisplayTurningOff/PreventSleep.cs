using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PreventDisplayTurningOff
{
    class PreventSleep
    {
        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            // Legacy flag, should not be used.
            // ES_USER_PRESENT   = 0x00000004,
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
        }

        public static class SleepUtil
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        }

        public static void PreventMachineFromSleeping()
        {
            //Away mode for Windows >= Vista
            if (SleepUtil.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | 
                                            EXECUTION_STATE.ES_DISPLAY_REQUIRED | 
                                            EXECUTION_STATE.ES_SYSTEM_REQUIRED | 
                                            EXECUTION_STATE.ES_AWAYMODE_REQUIRED) == 0)
            {
                //Windows < Vista, forget away mode
                EXECUTION_STATE temp = SleepUtil.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS
                    | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                    | EXECUTION_STATE.ES_SYSTEM_REQUIRED);

                temp = EXECUTION_STATE.ES_CONTINUOUS;
            }
        }

        public static void RestoreSetting()
        {
            SleepUtil.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
    }
}
