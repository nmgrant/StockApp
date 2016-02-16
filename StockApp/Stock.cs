using System;
using System.Threading;

namespace CECS475.Assignment3 {
    class Stock {

        // Event handler used for when stock value reaches a certain threshold
        // This stock event prints the status of the stock to the console
        public event EventHandler<StockNotificationEventArgs> stockEvent;

        // Event handler used for when stock value reaches a certain threshold
        // This stock event writes the status of the stock to the file
        public event EventHandler<StockToFileEventArgs> stockToFileEvent;

        // The name of the stock
        private string name;

        // An initial stock value that can't be changed
        private readonly int initialValue;

        // The current value of the stock
        private int currentValue;

        // The amount above or below the initial value that the stock
        // must go before an event is raised
        private readonly int threshold;

        // The highest amount that the stock value can be changed by
        private readonly int maxChange;

        // Stock constructor that takes a name, an initial value, max change,
        // and threshold. Also declares and starts a thread within the
        // constructor.
        public Stock(string name, int initialValue, int maxChange,
           int threshold) {
            this.name = name;
            this.initialValue = initialValue;
            this.threshold = threshold;
            this.maxChange = maxChange;
            currentValue = initialValue;
            // Initializes and starts a thread using a lambda expression as the
            // run behavior
            new Thread(() => {
                // Used to track changes of stock value
                int numberOfChanges = 0;

                // Infinite for-loop with an added 500ms delay between 
                // each loop iteration. Changes the stock value in each
                // iteration.
                for (;;) {
                    Thread.Sleep(500);
                    ChangeStockValue(ref numberOfChanges);
                }
            }).Start();
        }

        // public accessor for the stock's name
        public string Name { get; set; }

        // Method used to raise the event, called when the difference between
        // the stock's current value and its intial value is equal to the
        // threshold.
        protected void OnThresholdReached(StockNotificationEventArgs args1,
           StockToFileEventArgs args2) {

            // Calls the write to console event handler
            EventHandler<StockNotificationEventArgs> eventHandler = stockEvent;
            if (eventHandler != null) {
                eventHandler(this, args1);
            }

            // Calls the write to file event handler
            EventHandler<StockToFileEventArgs> fileHandler = stockToFileEvent;
            if (fileHandler != null) {
                fileHandler(this, args2);
            }
        }

        // Method called within the stock's thread that is used to
        // change the value of the stock. Raises on an event if
        // the threshold is reached
        public void ChangeStockValue(ref int numberOfChanges) {

            // Changes the current value by a random number between
            // 1 and the max change
            currentValue += new Random().Next(1, maxChange);

            // Increments this stock's number of changes
            numberOfChanges++;

            // Checks to see if the threshold was reached, calls
            // the event raised method if it has
            if (Math.Abs(currentValue - initialValue) > threshold) {
                OnThresholdReached(new StockNotificationEventArgs(name,
                   currentValue, numberOfChanges),
                   new StockToFileEventArgs(DateTime.Now, this.name,
                   this.currentValue, this.initialValue));
            }
        }
    }

    // Event data class for writing the stock information to the console
    // Data => Stock name, current value, and number of changes
    public class StockNotificationEventArgs : EventArgs {
        public string Name;
        public int CurrentValue;
        public int NumberOfChanges;

        public StockNotificationEventArgs(string name, int currentValue,
           int numberOfChanges) {
            Name = name;
            CurrentValue = currentValue;
            NumberOfChanges = numberOfChanges;
        }
    }

    // Event data class for writing the stock information to a file
    // Data => date and time of change, and name, current value, and initial
    // value of stock that changed
    public class StockToFileEventArgs : EventArgs {
        public DateTime DateTime;
        public string Name;
        public int CurrentValue;
        public int InitialValue;

        public StockToFileEventArgs(DateTime dateTime, string name,
           int currentValue, int initialValue) {
            DateTime = dateTime;
            Name = name;
            CurrentValue = currentValue;
            InitialValue = initialValue;
        }
    }
}
