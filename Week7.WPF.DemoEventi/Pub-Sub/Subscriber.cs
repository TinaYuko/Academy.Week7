using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.DemoEventi.Pub_Sub
{
    public class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        //Metodi di sottoscrizione e cancellazione dell'evento
        public void Subscribe(Publisher p)
        {
            p.OnPublish += OnNotificationReceived;
        }

        public void UnSubscribe (Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;

        }
        //Metodo che gestisce la ricezione della notifica
        protected virtual void OnNotificationReceived(Publisher p, Notification n)
        {
            Console.WriteLine($"Hi {SubscriberName}, {n}");
        }
    }
}
