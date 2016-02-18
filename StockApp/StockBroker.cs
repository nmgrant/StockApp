using System;
using System.Collections.Generic;

namespace CECS475.Assignment3 {
   class StockBroker {

      // The broker's name
      private String brokerName;

      // The broker's list of stocks
      private List<Stock> stocks;

      // A lock object used to ensure that only one thread accesses
      // the console at a time
      private static readonly object thisLock = new object();

      // StockBroker constructor initializing the name and list of stocks
      public StockBroker(String name) {
         this.brokerName = name;
         stocks = new List<Stock>();
      }

      // Multi-casts the stock being added to the broker's list with two
      // event handlers: the write to console handler, and the write
      // to file handler. Then, the stock is added to the broker's list
      public void AddStock(Stock stock) {
         stocks.Add(stock);
         stock.stockEvent += stockThresholdReached;
         stock.stockToFileEvent += StreamWriterClass.WriteToFile;
      }

      // Event handler used to write the status of the stock to 
      // the console. Additionally, if a the max number of stock thresholds
      // have been reached, the user is asked if they wish to continue.
      // If they do, the program continues, otherwise it exits.
      public void stockThresholdReached(object sender,
         StockNotificationEventArgs e) {

         // Using a lock ensures that no other thread tries to print to the 
         // console at the same time.
         lock (thisLock) {
            Console.WriteLine(brokerName.PadRight(20) + e.Name.PadRight(20)
            + e.CurrentValue.ToString().PadRight(15)
            + e.NumberOfChanges.ToString().PadRight(15));
         }
      }
   }
}
