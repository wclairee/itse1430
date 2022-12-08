/*
 * ITSE 1430
 */
namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
            _gridProducts.DataSource = _bsProducts;
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //_gridProducts.AutoGenerateColumns = false;

            var connString = Program.GetConnectionString("ProductDatabase");
            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");

            //TODO: Handle errors-completed
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _database.Add(child.Product);
                    UpdateList();
                    return;
                } catch (InvalidOperationException)
                {
                    DisplayError("Products must be unique.", "Add Failed.");
                } catch (ArgumentException)
                {
                    DisplayError("You messed up developer.", "Add Failed.");
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Add Failed.");
                };

            } while (true);

            //Save product
            //_database.Add(child.Product);
            //UpdateList();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }
        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //TODO: Handle errors-completed
            try
            {
                _database.Remove(product.Id);
                UpdateList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed.");
            };
            //Delete product
            _database.Remove(product.Id);
            UpdateList();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            //if (child.ShowDialog(this) != DialogResult.OK)
            //    return;

            //TODO: Handle errors-completed
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _database.Update(product.Id, child.Product);
                    System.Threading.Thread.Sleep(1000);

                    UpdateList();
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Update Failed.");
                } finally
                {
                    Cursor = Cursors.Default;
                };

            } while (true);
            //Save product
            //_database.Update(child.Product);
            //UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            var products = _database.GetAll();
            var items = products.OrderBy(x => x.Name);

            //TODO: Handle errors-completed
            try
            {
                _bsProducts.DataSource = items.ToList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Update Failed.");
            };
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private IProductDatabase _database = new Stores.Sql.SqlProductDatabase(Program.GetConnectionString("ProductDatabase"));
        #endregion
    }
}
