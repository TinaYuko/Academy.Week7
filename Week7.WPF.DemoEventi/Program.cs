// See https://aka.ms/new-console-template for more information
//Creazione dei publisher

using Week7.WPF.DemoEventi.Pub_Sub;

//Creo i publisher
Publisher youtube = new Publisher("YouTube.com");
Publisher instagram = new Publisher("Instagram");

//Subscribers
Subscriber sub1 = new Subscriber("Martina");
Subscriber sub2 = new Subscriber("Renata");
Subscriber sub3 = new Subscriber("Valentina");

sub1.Subscribe(youtube);
sub2.Subscribe(youtube);

sub3.Subscribe(instagram);
sub1.Subscribe(instagram);

//In un'applicazione wpf corrisponde al click del mouse
youtube.Publish();

Console.WriteLine("---------");

instagram.Publish();

Console.WriteLine("---------");

sub1.UnSubscribe(youtube);
youtube.Publish();