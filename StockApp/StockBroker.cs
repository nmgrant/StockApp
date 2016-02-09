using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp {
    class StockBroker {

        private String name;
        private List<Stock> stocks;

        public StockBroker(String name) {
            this.name = name;
        }

        public void AddStock(Stock stock) {
            stocks.Add(stock);
        }
    }
}
