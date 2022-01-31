using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.DemoEventi.Pub_Sub
{
    public class Notification
    {
        public string NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }
        public Notification(DateTime date, string message)
        {
            NotificationMessage = message;
            NotificationDate = date;    
        }

        public override string ToString()
        {
            return $"{NotificationDate} - {NotificationMessage}";
        }
    }
}
