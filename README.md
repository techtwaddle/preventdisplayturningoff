# preventingdisplayturningoff
This tool prevents your windows machine from going to sleep. If your machine is running Windows 8, it seems to go into sleep after a while; changing the power options sometimes does not seem to work. So when people want to remote to their machines from home, it won't work. 

Also, we had a scenario where we wanted to capture screenshots of the display for a long time (all night) , and needed the machine to be active. We run this tool on our machines and they never go to sleep, until you close the tool that is :)

The tool basically sets the execution state of a thread to EXECUTIONSTATE.ESDISPLAY_REQUIRED, preventing the machine from going to sleep. 

Has been tested on following versions:
- Windows 8
- Windows 7
- Windows Server 2008 R2