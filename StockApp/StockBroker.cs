using System;
using System.Collections.Generic;

namespace CECS475.Assignment3 {
    class StockBroker {

        private String name;
        private List<Stock> stocks;

        public StockBroker(String name) {
            this.name = name;
            stocks = new List<Stock>();
        }

        public void AddStock(Stock stock) {
            stocks.Add(stock);
        }
    }
}
