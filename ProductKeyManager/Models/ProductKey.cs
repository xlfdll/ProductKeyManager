using System;

namespace ProductKeyManager
{
    public class ProductKey
    {
        public Int32 ID { get; }
        public Product Product { get; }
        public String Key { get; }
        public ProductKeyType Type { get; }
        public String Version { get; }
        public Boolean IsTest { get; }
        public String Memo { get; }
    }
}