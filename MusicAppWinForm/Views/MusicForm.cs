using PresentationLayer.Presenters;
using PresentationLayer.EventArguments;

//Form control names start with a lowercase abbreviation of the type of control
#pragma warning disable IDE1006 // Naming Styles


namespace PresentationLayer
{
    public partial class MusicForm : Form, IMusicFormView
    {
        public MusicForm() =>
            InitializeComponent();


        //----------------- Events et al --------------------------------

        public event EventHandler? GetAll;
        public event EventHandler<SearchEventArgs>? SearchInAlbums;
        public event EventHandler<AlbumDataEventArgs>? AddEvent;
        public event EventHandler<AlbumDataEventArgs>? UpdateAlbumEvent;
        public event EventHandler? GetColumnNamesFromAlbumTableEvent;

        //---------------- helpers --------------------------------------

        protected static bool IsUrl(string input)
        {
            // Try to create a Uri object from the input string
            return Uri.TryCreate(input, UriKind.Absolute, out Uri? uriResult)
                ? uriResult != null && (uriResult.Scheme == Uri.UriSchemeHttp ||
                uriResult.Scheme == Uri.UriSchemeHttps)
                : false;
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Delete && e.Modifiers == Keys.None)
            {
                //In this code, we check if the pressed key is either a number key
                //from the top row(Keys.D0 to Keys.D9)
                //or a number key from the numpad (Keys.NumPad0 to Keys.NumPad9).
                bool isNumericKey = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                                    (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);

                e.SuppressKeyPress = !isNumericKey;
            }
        }

        //------------------ properties -----------------------------------

        public string Album_Title { get => txtAlbumTitle.Text; set => txtAlbumTitle.Text = value; }
        public string Artist { get => txtArtist.Text; set => txtArtist.Text = value; }
        public int Year
        {
            get
            {
                int.TryParse(txtYear.Text, out int year); //defaults to "0" if parse fails
                return year;
            }
            set => txtYear.Text = value.ToString();
        }
        public string Image_URL { get => txtImageURL.Text; set => txtImageURL.Text = value; }
        public string Description { get => txtDescription.Text; set => txtDescription.Text = value; }
        public int ID
        {
            get
            {
                int.TryParse(lblID.Text, out int id);
                return id;
            }
            set => lblID.Text = value.ToString();
        }

        public string Message { get; set; } = "";
        public bool CRUD_IsSuccessful { get; set; }
        public int RowsAffected { get; set; }
        public string SearchPhrase { get => Txt_Search.Text; set => Txt_Search.Text = value.ToString(); }
        public string? ColumnName { get => cmbSearchContext.SelectedValue.ToString(); }


        //----------------- main functionalities --------------------------

        //Set datasource with album(s) to show in DataGridView
        public void SetAlbumsBindingSource(BindingSource albums) =>
            dgvAll.DataSource = albums.DataSource;

        public void SetAlbumColumnNamesBindingSource(BindingSource albumColumns) =>
            cmbSearchContext.DataSource = albumColumns.DataSource;

        private void btnLoadAllAlbums_Click(object sender, EventArgs e)
        {
            GetAll?.Invoke(this, EventArgs.Empty);
            lblRowCountStatus.Text = "Records loaded: " + RowsAffected;
        }

        private void btnSearchInAlbums_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ColumnName))
            {
                SearchEventArgs searchArgs = new(SearchPhrase, ColumnName);
                SearchInAlbums?.Invoke(this, searchArgs);
                lblRowCountStatus.Text = "Records found: " + RowsAffected;
            }
        }

        private void btnAddNewAlbum_Click(object sender, EventArgs e)
        {
            AlbumDataEventArgs albumData =
               new()
               {
                   ID = ID,
                   Album_Title = Album_Title,
                   Artist = Artist,
                   Year = Year,
                   Image_URL = Image_URL,
                   Description = Description
               };

            AddEvent?.Invoke(this, albumData);

            if (CRUD_IsSuccessful)
            {
                lblRowCountStatus.ForeColor = Color.Green;
                lblRowCountStatus.Text = "Records inserted: " + RowsAffected;
            }
            else
            {
                lblRowCountStatus.ForeColor = Color.Red;
                lblRowCountStatus.Text = "Record insertion Failed: " + RowsAffected;
                MessageBox.Show(Message);
            }
        }

        private void dgvAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowClicked = e.RowIndex;
            if (rowClicked > -1 && rowClicked <= ((DataGridView)sender).RowCount)
            {
                DataGridView dgv = (DataGridView)sender;
                string? imageURL = dgv.Rows[rowClicked].Cells[4].Value.ToString();

                try
                {
                    if (!string.IsNullOrEmpty(imageURL) && IsUrl(imageURL))
                        AlbumImageBox.Load(imageURL);
                }
                // Some sources won't allow hotlinking, for example,
                // whilst Wikimedia has special kind of identification requirements.
                catch (System.Net.WebException ex)
                {
                    if (ex.Response is System.Net.HttpWebResponse response &&
                        response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                        MessageBox.Show("Access to the image is currently forbidden.");
                    else
                        MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void dgvAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int rowClicked = e.RowIndex;
            if (rowClicked > -1 && rowClicked <= dgv.RowCount)
            {
                lblID.Text = dgv.CurrentRow.Cells["ID"].Value.ToString();
                txtAlbumTitle.Text = dgv.CurrentRow.Cells["Album_Title"].Value.ToString();
                txtArtist.Text = dgv.CurrentRow.Cells["Artist"].Value.ToString();
                txtYear.Text = dgv.CurrentRow.Cells["Year"].Value.ToString();
                txtImageURL.Text = dgv.CurrentRow.Cells["Image_URL"].Value.ToString();
                txtDescription.Text = dgv.CurrentRow.Cells["Description"].Value.ToString();

                foreach (Control control in groupAddOrEdit.Controls)
                {
                    if (control is TextBox textBox)
                        textBox.ReadOnly = false;
                }
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            AlbumDataEventArgs albumData = new()
            {
                ID = ID,
                Album_Title = Album_Title,
                Artist = Artist,
                Year = Year,
                Image_URL = Image_URL,
                Description = Description
            };

            UpdateAlbumEvent?.Invoke(this, albumData);

            if (CRUD_IsSuccessful)
            {
                lblRowCountStatus.ForeColor = Color.Green;
                lblRowCountStatus.Text = "Records updated: " + RowsAffected;
            }
            else
            {
                lblRowCountStatus.ForeColor = Color.Red;
                lblRowCountStatus.Text = "Record update Failed. Records updated: " + RowsAffected;
                MessageBox.Show(Message);
            }

        }

        private void btnAbortEdit_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupAddOrEdit.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ReadOnly = true;
                    textBox.Text = "";
                }
            }
        }

        private void MusicForm_Load(object sender, EventArgs e)
        {
            GetColumnNamesFromAlbumTableEvent?.Invoke(this, e);
        }
    }
}