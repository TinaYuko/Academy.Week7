using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.DemoEventi.Pub_Sub
{
    public class Publisher
    {
        public string PublisherName { get; set; }
        public Publisher(string publisherName)
        {
            PublisherName = publisherName;
        }
        //Dichiaro l'evento
        public event Notify OnPublish;

        public delegate void Notify(Publisher p, Notification notification);

        //Metodo che effettivamente si occupa di pubblicare l'evento
        public void Publish()
        {
            if (OnPublish!=null)
            {
                Notification n = new Notification(DateTime.Now, $"Notifica da parte di {PublisherName}");
                OnPublish(this, n);
                
            }
        }
    }
}
