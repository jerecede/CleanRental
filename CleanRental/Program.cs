namespace CleanRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tui = new Tui(new BusinessLogic(new CleanRentalContext()));
            tui.Run();
        }
    }
}
