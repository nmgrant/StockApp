using System;
using System.Threading;

namespace CECS475.Assignment3 {
    class Stock { 

        public event EventHandler<StockNotificationEventArgs> stockEvent;

        private String name;
        private readonly int initialValue;
        private int currentValue;
        private readonly int threshold;
        private readonly int maxChange;

        public Stock(String name, int initialValue, int maxChange, int threshold) {
            this.name = name;
            this.initialValue = initialValue;
            this.threshold = threshold;
            this.maxChange = maxChange;
            currentValue = initialValue;
            // Initializes and starts a thread using a lambda expression as the run behavior
            new Thread(() => {
                int numberOfChanges = 0;
                for (;;) {
                    Thread.Sleep(500);
                    ChangeStockValue(ref numberOfChanges);
                }
            }).Start();
        }

        public String Name { get; set; }

        protected void OnThresholdReached(StockNotificationEventArgs args) {
            EventHandler<StockNotificationEventArgs> handler = stockEvent;
            if (handler != null) {
                handler(this, args);
            }
        }

        public void ChangeStockValue(ref int numberOfChanges) {
            currentValue += new Random().Next(-maxChange, maxChange);
            numberOfChanges++;
            if (Math.Abs(currentValue - initialValue) > threshold) {
                OnThresholdReached(new StockNotificationEventArgs(name, currentValue, numberOfChanges));
            }
        }
    }

    public class StockNotificationEventArgs : EventArgs {
        public String Name;
        public int CurrentValue;
        public int NumberOfChanges;

        public StockNotificationEventArgs(String name, int currentValue, int numberOfChanges) {
            Name = name;
            CurrentValue = currentValue;
            NumberOfChanges = numberOfChanges;
        }
    }
}
