using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp {
    class Stock {

        private String name;
        private readonly int initialValue;
        private readonly int threshold;
        private readonly int maxChange;

        public Stock(String name, int initialValue, int threshold, int maxChange) {
            this.name = name;
            this.initialValue = initialValue;
            this.threshold = threshold;
            this.maxChange = maxChange;
            // Initializes a thread using a lambda expression as the run behavior
            Thread thread = new Thread(() => {
                Thread.Sleep(500);
                Console.WriteLine(this.name);
            });
            thread.Start();
        }
    }
}
