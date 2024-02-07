namespace GetGreeting
{
    internal class TimeProvider : iTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
