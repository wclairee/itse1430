/*
 * ITSE 1430
 */
namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        {
            //TODO: Check arguments-completed
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var existing = FindByName(product.Name);
            if (existing != null)
                throw new InvalidOperationException("Product name must be unique.");

            //TODO: Validate product-completed
            ObjectValidator.Validate(product);

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {
            //TODO: Check arguments-completed
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be >= 0.");

            return GetCore(id);
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public void Remove ( int id )
        {
            //TODO: Check arguments-completed
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be >= 0.");

            RemoveCore(id);
        }

        /// <inheritdoc />
        public void Update ( int id, Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //TODO: Validate product-completed
            ObjectValidator.Validate(product);

            //Get existing product
            var oldProduct = GetCore(product.Id);
            if (oldProduct == null)
                throw new ArgumentException("Product does not exist.", nameof(product));

            var existing = FindByName(product.Name);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Product name must be unique.");
           
            try
            {
                UpdateCore(product);
            } catch (Exception e)
            {
                throw new Exception("Update failed", e);
            };
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract void UpdateCore( Product product );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindByName ( string name );
        #endregion
    }
}
