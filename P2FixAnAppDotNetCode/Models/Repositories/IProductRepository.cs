using System.Collections.Generic;
// Appel using pour List<Product>


namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        //Ajout méthode getProductById
        Product GetProductById(int id);

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
