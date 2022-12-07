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
        public void Update ( Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //TODO: Validate product-completed
            ObjectValidator.Validate(product);

            //Get existing product
            var existing = GetCore(product.Id);
            if (existing == null)
                throw new ArgumentException("Product does not exist.", nameof(product));

            try
            {
                UpdateCore(existing, product);
            } catch (Exception e)
            {
                throw new Exception("Update failed", e);
            };
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}
