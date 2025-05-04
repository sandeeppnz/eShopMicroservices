namespace Catalog.API.Exceptions
{
    [Serializable]
    internal class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product Not Found")
        {
        }
    }
}