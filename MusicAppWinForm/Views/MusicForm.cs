using PresentationLayer.Presenters;
using PresentationLayer.DTO;
using System.Data;

namespace PresentationLayer
{
    public partial class MusicForm : Form, IMainView
    {
        public MusicForm()
        {
            InitializeComponent();
        }

        //----------------- Events et al --------------------------------

        public event EventHandler? GetAll;
        public event Action<object, string, string?>? SearchInAlbums;
        public event Func<object, AlbumDTO, int>? Add;
        public event Func<object, AlbumDTO, int>? UpdateAlbumEvent;
        public event EventHandler? GetColumnNamesFromAlbumTable;


        //---------------- helpers --------------------------------------

        protected static bool IsUrl(string input)
        {
            // Try to create a Uri object from the input string
            return Uri.TryCreate(input, UriKind.Absolute, out Uri? uriResult)
                ? uriResult != null && (uriResult.Scheme == Uri.UriSchemeHttp ||
                uriResult.Scheme == Uri.UriSchemeHttps)
                : false;
        }
        private void Txt_Year_KeyDown(object sender, KeyEventArgs e)
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

        public string Album_Title { get => Txt_AlbumTitle.Text; set => Txt_AlbumTitle.Text = value; }
        public string Artist { get => Txt_Artist.Text; set => Txt_Artist.Text = value; }
        public int Year
        {
            get
            {
                int.TryParse(Txt_Year.Text, out int year); //defaults to "0" if parse fails
                return year;
            }
            set => Txt_Year.Text = value.ToString();
        }
        public string Image_URL { get => Txt_ImageURL.Text; set => Txt_ImageURL.Text = value; }
        public string Description { get => Txt_Description.Text; set => Txt_Description.Text = value; }
        public int ID
        {
            get
            {
                int.TryParse(lbl_ID.Text, out int id);
                return id;
            }
            set => lbl_ID.Text = value.ToString();
        }

        public string Message { get; set; } = "";
        public bool CRUD_IsSuccessful { get; set; }



        //----------------- main functionalities --------------------------

        //Set datasource with album(s) to show in DataGridView
        public void SetAlbumsBindingSource(BindingSource albums) =>
            DataGridViewAll.DataSource = albums.DataSource;

        public void SetAlbumColumnNamesBindingSource(BindingSource albumColumns) =>
            cmbSearchContext.DataSource = albumColumns.DataSource;

        private void Btn_LoadAllAlbums_Click(object sender, EventArgs e) =>
            GetAll?.Invoke(this, EventArgs.Empty);

        private void Btn_SearchInAlbums_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSearchContext.SelectedValue.ToString()))
                SearchInAlbums?.Invoke(this, Txt_Search.Text, cmbSearchContext.SelectedValue.ToString());
        }

        private void Btn_AddNewAlbum_Click(object sender, EventArgs e)
        {
            AlbumDTO albumData =
               new()
               {
                   ID = ID,
                   Album_Title = Album_Title,
                   Artist = Artist,
                   Year = Year,
                   Image_URL = Image_URL,
                   Description = Description
               };

            int? rowsAffected = Add?.Invoke(this, albumData);

            if (CRUD_IsSuccessful)
            {
                Lbl_AddSuccess.ForeColor = Color.Green;
                Lbl_AddSuccess.Text = "Records inserted: " + rowsAffected.ToString();
            }
            else
            {
                Lbl_AddSuccess.ForeColor = Color.Red;
                Lbl_AddSuccess.Text = "Record insertion Failed";
                MessageBox.Show(Message);
            }
        }

        private void DataGridViewAll_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void DataGridViewAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int rowClicked = e.RowIndex;
            if (rowClicked > -1 && rowClicked <= dgv.RowCount)
            {
                lbl_ID.Text = dgv.CurrentRow.Cells["ID"].Value.ToString();
                Txt_AlbumTitle.Text = dgv.CurrentRow.Cells["Album_Title"].Value.ToString();
                Txt_Artist.Text = dgv.CurrentRow.Cells["Artist"].Value.ToString();
                Txt_Year.Text = dgv.CurrentRow.Cells["Year"].Value.ToString();
                Txt_ImageURL.Text = dgv.CurrentRow.Cells["Image_URL"].Value.ToString();
                Txt_Description.Text = dgv.CurrentRow.Cells["Description"].Value.ToString();

                foreach (Control control in groupAddOrEdit.Controls)
                {
                    if (control is TextBox textBox)
                        textBox.ReadOnly = false;
                }
            }
        }

        private void Btn_SaveEdit_Click(object sender, EventArgs e)
        {
            AlbumDTO albumData = new()
            {
                ID = ID,
                Album_Title = Album_Title,
                Artist = Artist,
                Year = Year,
                Image_URL = Image_URL,
                Description = Description
            };

            int? rowChanged = UpdateAlbumEvent?.Invoke(this, albumData);

            if (CRUD_IsSuccessful && rowChanged == 1)
            {
                Lbl_AddSuccess.ForeColor = Color.Green;
                Lbl_AddSuccess.Text = "Records updated: " + rowChanged.ToString();
            }
            else
            {
                Lbl_AddSuccess.ForeColor = Color.Red;
                Lbl_AddSuccess.Text = "Record update Failed";
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
            GetColumnNamesFromAlbumTable?.Invoke(this, e);
        }
    }
}