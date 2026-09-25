using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            // FIX:
            // GetAllProducts now returns a List<Product> instead of a Product[].
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // Correction :
            // Search the product list and return the product
            // whose Id matches the Id received as a parameter.
            return _productRepository
                .GetAllProducts()
                .FirstOrDefault(p => p.Id == id);

        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            if (cart == null) return;

            foreach (var line in cart.Lines)
            {
                if (line?.Product == null) continue;
                _productRepository.UpdateProductStocks(line.Product.Id, line.Quantity);
            }
        }
    }
}
