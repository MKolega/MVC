Task t1 = Task.Run(() =>
{
    Console.WriteLine($"Sleeping started");
    Thread.Sleep(1000);
    Console.WriteLine($"Sleeping completed");


});

Task t2 = Task.Run(() =>
{
    Console.WriteLine($"Sleeping started");
    Thread.Sleep(1500);
    Console.WriteLine($"Sleeping completed");
});
Console.WriteLine($"Waiting on task..");


Task.WaitAll(t1,t2);

Console.WriteLine($"Done!");

static async Task SleepF1()
{
    await SleepF2();
    Console.WriteLine($"Sleeping started");
    await Task.Delay(1000);
    Console.WriteLine($"Sleeping completed");
}
static async Task SleepF2()
{
    Console.WriteLine($"Sleeping started");
    await Task.Delay(1500);
    Console.WriteLine($"Sleeping completed");

}
Task task = SleepF1();
task.Wait();
Console.WriteLine($"Done!");