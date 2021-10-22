using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Threading;

namespace Gramada_Cosmin_Lab_3
{
    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }

    class DoughnutMachine : Component
    {
        private DoughnutType m_Flavor;
        private ArrayList m_Doughnuts = new();

        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;
        DispatcherTimer doughnutTimer;

        public DoughnutMachine()
        {
            InitializeComponent();
        }

        public void MakeDoughnuts(DoughnutType flavor)
        {

            Flavor = flavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed:
                    { 
                        Interval = 3; 
                        break; 
                    }
                case DoughnutType.Sugar:
                    {
                        Interval = 2;
                        break;
                    }
                case DoughnutType.Lemon:
                    {
                        Interval = 5;
                        break;
                    }
                case DoughnutType.Chocolate:
                    {
                        Interval = 7;
                        break;
                    }
                case DoughnutType.Vanilla:
                    {
                        Interval = 4;
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException($"Invalid Flavor {Flavor}");
                    }
            }
            doughnutTimer.Start();
        }

        private void InitializeComponent()
        {
            doughnutTimer = new DispatcherTimer();
            doughnutTimer.Tick += new EventHandler(doughnutTimer_Tick);
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(Flavor);
            m_Doughnuts.Add(aDoughnut);
            DoughnutComplete();
        }

        public DoughnutType Flavor
        {
            get => m_Flavor;
            set => m_Flavor = value;
        }

        public Doughnut this[int Index]
        {
            get => (Doughnut)m_Doughnuts[Index];
            set => m_Doughnuts[Index] = value;
        }

        public bool Enabled
        {
            set => doughnutTimer.IsEnabled = value;
        }
        public int Interval
        {
            set => doughnutTimer.Interval = new TimeSpan(0, 0, value);
        }
    }

    class Doughnut
    {
        private DoughnutType m_Flavor;
        private float m_Price = .50F;
        private readonly DateTime m_TimeOfCreation;

        public Doughnut(DoughnutType flavor)
        {
            m_TimeOfCreation = DateTime.Now;
            m_Flavor = flavor;
        }

        public DoughnutType Flavor
        {
            get => m_Flavor;
            set => m_Flavor = value;
        }

        public float Price
        {
            get => m_Price;
            set => m_Price = value;
        }

        public DateTime TimeOfCreation => m_TimeOfCreation;
    }
}
