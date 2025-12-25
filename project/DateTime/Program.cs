using System;

namespace UsingDateTime
{
    public struct Event
    {
        public DateTime StartDate;
        public DateTime EndDate;
        
        public Event(DateTime start, DateTime end){
            StartDate = start;
            EndDate = end;
        }
        
        public double GetDuration(){
            TimeSpan duration = EndDate - StartDate;
            return duration.TotalDays;
        }
        public bool IsOverlapping(Event otherEvent){
            return this.StartDate < otherEvent.EndDate && otherEvent.StartDate < this.EndDate;
        }
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            Event one = new Event(new DateTime(2024,07,01), new DateTime(2024,07,10));
            Event two = new Event(new DateTime(2024,07,05), new DateTime(2024,07,15));
            
            Console.WriteLine("Event 1 Duration: " + one.GetDuration()+ " days");
            Console.WriteLine("Event 2 Duration: " + two.GetDuration()+ " days");
            Console.WriteLine("Events Overlap: " + one.IsOverlapping(two));
            
        }
    }
}
