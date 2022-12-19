using NetCafeUCN.MVC.Services;

namespace NetCafeUCN.tests
{
    public class PerformanceTest
    {
        [Fact]
        public void MVCBookingAPIPerformanceTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BookingService bookingService = new BookingService("http://79.171.148.186/api/");
            bookingService.GetAll();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Assert.True(elapsedMs < 1000);
        }
        
        [Fact]
        public void MVCCustomerAPIPerformanceTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CustomerService customerService = new CustomerService("http://79.171.148.186/api/");
            customerService.GetAll();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Assert.True(elapsedMs < 1000);
        }
        
        [Fact]
        public void MVCUserAPIPerformanceTest()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            UserProviderService userService = new UserProviderService("http://79.171.148.186/api/");
            userService.GetHashByEmail("Maluku@gmail.com");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Assert.True(elapsedMs < 1000);
        }

    }
}
