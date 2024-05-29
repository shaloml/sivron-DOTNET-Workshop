namespace DI.Demo.MultiTenantApplication
{
    public class PremiumService : IService
    {
        public void Execute()
        {
            Console.WriteLine("Premium Service Execution");
        }
    }

}
