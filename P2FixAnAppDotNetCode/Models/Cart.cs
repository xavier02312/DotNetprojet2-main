using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        // Ajout champs priver de panier
        private List<CartLine> _cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => _cartLines;

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // Appel du panier vide
            CartLine cartLine = null;
            //TODO implement AddItem DONE
            // Recherchez si le produit est déjà dans le panier
            foreach (var line in _cartLines)
            {
                if (line.Product.Id == product.Id)
                {
                    cartLine = line;
                    break;
                }
            }

            // Si le produit est déjà dans le panier, augmentez la quantité
            if (cartLine != null)
            {
                cartLine.Quantity += quantity;
            }
            // Sinon, ajoutez un nouvel élément CartLine au panier
            else
            {
                _cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            // déclaration du total à 2 chiffre avec une virgule
            double _TotalValue = 0.0;
            // boucle sur le panier pour trouver les prix de product
            foreach (var line in _cartLines)
            {
                _TotalValue += line.Product.Price * line.Quantity;
            }
            // Retournez le prix 
            return _TotalValue;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            // Déclaration de la valeur moyenne 
            double _AverageValue = 0.0;
            // Déclaration du nombre dd produit à 0
            int nbArticle = 0;

            // Boucle sur le panier
            foreach (var line in _cartLines)
            {
                nbArticle += line.Quantity; //Ajoute le nombre d'article 
            }
            // Vérifiez si nbArticle est supérieur à zéro avant de faire la division
            if (nbArticle > 0)
            {
                _AverageValue = GetTotalValue() / nbArticle;
            }

            return _AverageValue;  // Retournez la valeur moyenne
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            // Déclare le produit à pas de produit
            Product product = null;

            // Compare chaque identifiant de chaque produit avec l'identifiant fourni
            foreach (var line in _cartLines)
            {
                //Renvoie le produit correspondant  à l'ID
                if (line.Product.Id == productId)
                {
                    return line.Product; // retournez le produit
                }
            }
            // retournez rien sinon
            return null;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
