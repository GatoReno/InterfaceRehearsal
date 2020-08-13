using System;
using System.Net.WebSockets;

namespace DelegatesRehearsal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myPayment = new Payment();
            myPayment.PaymentFailed += OnMyFailed;
            myPayment.PaymentFailed += (error) => Console.WriteLine($"this otro failed: {error}");
            myPayment.PaymentErrorHandler = new x();
            myPayment.ApplyPayment();

            myPayment.PaymentFailed -= OnMyFailed;         

        }

        static void OnMyFailed(string x)
        {
            Console.WriteLine($"this failed: {x}");

        }
    }

    public delegate void OnFailed(string error);

    public interface IPaymentErrorHandler
    {
        void OnError(string errormessage);
    }

    public class x : IPaymentErrorHandler
    {
        public void OnError(string errormessage)
        {
            Console.WriteLine($"from interface failed: {errormessage}");

        }
    }

    public class Payment 
    {
        public IPaymentErrorHandler PaymentErrorHandler { get; set; }
        public OnFailed PaymentFailed;
        public void ApplyPayment() 
        {
            try
            {
                ///provdso heavy
                 throw new Exception("Failed because I dont like you");
                Console.WriteLine("Applying payment......");
                
            }
            catch (Exception ex)
            {
                PaymentErrorHandler?.OnError(ex.Message);
                PaymentFailed?.Invoke(ex.Message);
            }
        }

    }
}
