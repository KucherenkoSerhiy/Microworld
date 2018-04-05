using System.Threading;

namespace Assets.Backend.Model
{
    public class AbilityLocker
    {
        public bool IsActive { get; private set; }

        public AbilityLocker()
        {
            IsActive = true;
        }

        public void DeactivateForTime(int time_ms)
        {
            new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true;

                IsActive = false;
                Thread.Sleep(time_ms);
                IsActive = true;
            }).Start();
        }
    }
}