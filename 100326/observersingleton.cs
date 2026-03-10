using System;
using System.Collections.Generic;
namespace NewsApp 
{
    public interface ISub { void Update(string msg); }
    public interface IAgency 
    {
        void Attach(ISub sub);
        void Detach(ISub sub);
        void Notify();
    }
    // observer+singleton
    public class NewsAgency : IAgency
    {
        private static NewsAgency _instance;
        private List<ISub> _subs = new List<ISub>();
        private string _news;
        public string News
        {
            get => _news;
            set { _news = value; Notify(); }
        }
        private NewsAgency() { }
        public static NewsAgency Instance => _instance ??= new NewsAgency();

        public void Attach(ISub sub) => _subs.Add(sub);
        public void Detach(ISub sub) => _subs.Remove(sub);
        public void Notify() => _subs.ForEach(s => s.Update(_news));
    }
    // abonati
    public class MobileApp : ISub 
    { 
        public void Update(string msg) => Console.WriteLine($"[Mobile] {msg}"); 
    }
    public class EmailClient : ISub 
    { 
        public void Update(string msg) => Console.WriteLine($"[Email] {msg}"); 
    }
    class Program
    {
        static void Main()
        {
            var agency = NewsAgency.Instance;
            agency.Attach(new MobileApp());
            agency.Attach(new EmailClient());

            bool go = true;
            while (go)
            {
                Console.Write("\nInserisci News (o 'esci'): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "esci") go = false;
                else agency.News = input;
            }
        }
    }
}