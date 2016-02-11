using System;
using System.Collections.Generic;
using System.IO;

namespace CECS475.Assignment3 {
    class StockBroker {

        private String brokerName;
        private List<Stock> stocks;

        public StockBroker(String name) {
            this.brokerName = name;
            stocks = new List<Stock>();
        }

        public void AddStock(Stock stock) {
            stock.stockEvent += stockThresholdReached;
            stock.stockToFileEvent += StreamWriterClass.WriteToFile;
            stocks.Add(stock);
        }

        public void stockThresholdReached(object sender, StockNotificationEventArgs e) {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Name, e.NumberOfChanges);
        }
    }
}
