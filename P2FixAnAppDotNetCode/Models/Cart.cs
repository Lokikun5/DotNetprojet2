using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        // Correction:
        // Store cart lines in a persistent list instead of creating
        // a new empty list every time GetCartLineList() is called.
        private readonly List<CartLine> _cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        private List<CartLine> GetCartLineList()
        {
            // Correction:
            // Return the same list so products remain stored in the cart.
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity
        /// if already added
        /// </summary>
        public void AddItem(Product product, int quantity)
        {
            //FIX
            // Search for an existing line containing the same product.
            CartLine line = GetCartLineList()
                .FirstOrDefault(l => l.Product.Id == product.Id);

            if (line == null)
            {
                // Product not in cart:
                // create a new cart line with the requested quantity.
                GetCartLineList().Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                // Product already in cart:
                // increment the existing quantity.
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Removes a product from the cart
        /// </summary>
        public void RemoveLine(Product product)
        {
            GetCartLineList()
                .RemoveAll(l => l.Product.Id == product.Id);
        }

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // FIX Total = sum of (price * quantity) for each cart line
            return GetCartLineList().Sum(l => (l.Product?.Price ?? 0.0) * l.Quantity);
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // FIX Implement the method to calculate the average value
            var cartLines = GetCartLineList();
            if (!cartLines.Any()) return 0.0;
            return cartLines.Average(l => (l.Product?.Price ?? 0.0) * l.Quantity);
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            //FIX Implement the method to find a product by its ID in the cart lines
            var line = GetCartLineList().FirstOrDefault(l => l.Product != null && l.Product.Id == productId);
            return line?.Product;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears the cart of all added products
        /// </summary>
        public void Clear()
        {
            GetCartLineList().Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}