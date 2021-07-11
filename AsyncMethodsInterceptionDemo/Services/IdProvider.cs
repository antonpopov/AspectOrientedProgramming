
namespace AsyncMethodsInterceptionDemo.Services
{
    public static class IdProvider
    {
        private static int Id;

        public static int GenerateId()
        {
            return ++Id;
        }
    }
}
