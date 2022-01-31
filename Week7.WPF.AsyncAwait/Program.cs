
using System.Diagnostics;
using Week7.WPF.AsyncAwait;

    Stopwatch timer = Stopwatch.StartNew();

    Coffee coffee = PourCoffee();
    //Console.WriteLine("Kaffè pronto!");
    //Egg eggs = await FryEggsAsync(2);
    //Console.WriteLine("Uova pronte!");
    //Bacon bacon = await FryBaconAsync(3);
    //Console.WriteLine("Bacon pronto!");
    //Toast toast = await ToastBreadAsync(2);
    //ApplyButter(toast);
    //ApplyJam(toast);
    //Console.WriteLine("Toast pronto!");
    //Juice oj = PourOJ();
    //Console.WriteLine("Succo pronto!");
    //Console.WriteLine("Mo finalmente posso mangiare, BUONGIORNISSIMO KAFFE'");
    //Console.WriteLine($"Per prepararla ci ho messo {timer.ElapsedMilliseconds} ms");
    Console.WriteLine();
    

    //Lancio multithread
    Task<Egg> eggsTask = FryEggsAsync(2);
    Task<Bacon> baconTask = FryBaconAsync(3);
    Task<Toast> toastTask = ToastBreadAsync(2);

    Toast toast = await toastTask;
    ApplyButter(toast);
    ApplyButter(toast);
    Console.WriteLine("Toast pronto!");
    Juice oj = PourOJ();
    Console.WriteLine("Succo pronto!");
    Egg eggs = await eggsTask;
    Console.WriteLine("Uova pronte!");
    Bacon bacon = await baconTask;
    Console.WriteLine("Bacon pronto!");
    Console.WriteLine("Mo finalmente posso mangiare, BUONGIORNISSIMO KAFFE'");
    
    Console.WriteLine($"Per prepararla ci ho messo {timer.ElapsedMilliseconds} ms");


static async Task<Toast> ToastBreadAsync(int v)
{
    for (int i = 0; i < v; i++)
    {
        Console.WriteLine("Messo il toast nel tostapane");
    }
    Console.WriteLine("Stanno tostando");
    await Task.Delay(3000);
    Console.WriteLine("Mi hanno fatto azziccare come sempre, ora li tolgo");
    return new Toast();
}

static async Task<Bacon> FryBaconAsync(int v)
{
    Console.WriteLine("Metto il bacon");
    Console.WriteLine("Asciugo il grasso");
    await Task.Delay(3000);
    for (int i = 0; i < v; i++)
    {
        Console.WriteLine("Giro il bacon");
    }
    Console.WriteLine("Aspetto che si scaldi l'altra parte");
    await Task.Delay(3000);
    Console.WriteLine("Metto il bacon nel piatto");
    return new Bacon();
}

static async Task<Egg> FryEggsAsync(int v)
{
    Console.WriteLine("Scaldo la padella...");
    await Task.Delay(3000);
    Console.WriteLine($"Rompo {v} uova");
    await Task.Delay(3000);
    return new Egg();
}

static Juice PourOJ()
{
    Console.WriteLine("Verso il succo");
    return new Juice();
}

static void ApplyButter(Toast toast)
{
    Console.WriteLine("Metto il burro");
}

static void ApplyJam(Toast toast)
{
    Console.WriteLine("Metto la marmellata");
}

static Toast ToastBread(int v)
{
    for (int i = 0; i < v; i++)
    {
        Console.WriteLine("Messo il toast nel tostapane");
    }
    Console.WriteLine("Stanno tostando");
    Task.Delay(3000).Wait();
    Console.WriteLine("Mi hanno fatto azziccare come sempre, ora li tolgo");
    return new Toast();
}

static Bacon FryBacon(int v)
{
    Console.WriteLine("Metto il bacon");
    Console.WriteLine("Asciugo il grasso");
    Task.Delay(3000).Wait();
    for (int i = 0; i < v; i++)
    {
        Console.WriteLine("Giro il bacon");
    }
    Console.WriteLine("Aspetto che si scaldi l'altra parte");
    Task.Delay(3000).Wait();
    Console.WriteLine("Metto il bacon nel piatto");
    return new Bacon();
}

static Egg FryEggs(int v)
{
    Console.WriteLine("Scaldo la padella...");
    Task.Delay(3000).Wait();
    Console.WriteLine($"Rompo {v} uova");
    Task.Delay(3000).Wait();
    return new Egg();
}

static Coffee PourCoffee()
{
    Console.WriteLine("Preparandone il caffè");
    return new Coffee();
}