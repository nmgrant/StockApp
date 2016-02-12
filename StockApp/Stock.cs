using System;
using System.Threading;

namespace CECS475.Assignment3 {
   class Stock {

      public event EventHandler<StockNotificationEventArgs> stockEvent;
      public event EventHandler<StockToFileEventArgs> stockToFileEvent;

      private string name;
      private readonly int initialValue;
      private int currentValue;
      private readonly int threshold;
      private readonly int maxChange;

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
            int numberOfChanges = 0;
            for (;;) {
               Thread.Sleep(500);
               ChangeStockValue(ref numberOfChanges);
            }
         }).Start();
      }

      public string Name { get; set; }

      protected void OnThresholdReached(StockNotificationEventArgs args1,
         StockToFileEventArgs args2) {
         EventHandler<StockNotificationEventArgs> eventHandler = stockEvent;
         if (eventHandler != null) {
            eventHandler(this, args1);
         }

         EventHandler<StockToFileEventArgs> fileHandler = stockToFileEvent;
         if (fileHandler != null) {
            fileHandler(this, args2);
         }
      }

      public void ChangeStockValue(ref int numberOfChanges) {
         currentValue += new Random().Next(1, maxChange);
         numberOfChanges++;
         if (Math.Abs(currentValue - initialValue) > threshold) {
            OnThresholdReached(new StockNotificationEventArgs(name,
               currentValue, numberOfChanges),
               new StockToFileEventArgs(DateTime.Now, this.name,
               this.currentValue, this.initialValue));
         }
      }
   }

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
