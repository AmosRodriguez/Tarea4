using System;
using System.Collections.Generic;

namespace patronobserver_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Medidor medidor = new Medidor();

            NewsAgency agency1 = new NewsAgency("Alpha");
            medidor.Attach(agency1);

            NewsAgency agency2 = new NewsAgency("Omega");
            medidor.Attach(agency2);

            NewsAgency agency3 = new NewsAgency("Delta");
            medidor.Attach(agency3);

            medidor.Temperatura = 22.1f;
            medidor.Temperatura = 28f;
            medidor.Temperatura = 30.5f;
            medidor.Temperatura = 10.3f;

            Console.ReadLine();
        }
    }
    interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }

    class Medidor : ISubject
    {
        private List<IObserver> _observers;
        public float Temperatura
        {
            get{ return temperatura; }
            set
            {
                temperatura = value;
                Notify();
            }

        } 
        
        public float temperatura;
        public Medidor()
        {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }
    }

    interface IObserver
    {
        void Update(ISubject subject);
    }

    class NewsAgency : IObserver
    {
        public String AgencyName { get; set; }
        public NewsAgency(String name)
        {
            AgencyName = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is Medidor medidor)
            {
                Console.WriteLine(String.Format("{0} tiene un reporte de temperatura de {1} grados celcius", AgencyName, medidor.temperatura));
                Console.WriteLine();
            }
        }
    }
}
