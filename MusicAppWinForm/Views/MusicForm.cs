using PresentationLayer.Presenters;
using PresentationLayer.Views.EventArguments;

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
        public event EventHandler<string>? SearchInAlbums;
        public event Func<object, AddOrEditEventArgs, int>? Add;

        //---------------- helpers --------------------------------------

        protected static bool IsUrl(string input)
        {
            // Try to create a Uri object from the input string
            return Uri.TryCreate(input, UriKind.Absolute, out Uri? uriResult)
                ? uriResult != null && (uriResult.Scheme == Uri.UriSchemeHttp ||
                uriResult.Scheme == Uri.UriSchemeHttps)
                : false;
        }

        //------------------ properties -----------------------------------

        public string Album_Title { get => Txt_AlbumTitle.Text; set => Txt_AlbumTitle.Text = value; }
        public string Artist { get => Txt_Artist.Text; set => Txt_Artist.Text = value; }
        public String Year { get => Txt_Year.Text; set => Txt_Year.Text = value.ToString(); }
        public string Image_URL { get => Txt_ImageURL.Text; set => Txt_ImageURL.Text = value; }
        public string Description { get => Txt_Description.Text; set => Txt_Description.Text = value; }

        public string Message { get; set; } = "";
        public bool CRUD_IsSuccessful { get; set; }

        //----------------- main functionalities --------------------------

        //Set datasource with album(s) to show in DataGridView
        public void SetAlbumsBindingSource(BindingSource albums) =>
            DataGridViewAll.DataSource = albums.DataSource;

        private void Btn_LoadAllAlbums_Click(object sender, EventArgs e) =>
            GetAll?.Invoke(this, EventArgs.Empty);

        private void Btn_SearchInAlbums_Click(object sender, EventArgs e) =>
            SearchInAlbums?.Invoke(this, Txt_Search.Text);

        private void Btn_AddNewAlbum_Click(object sender, EventArgs e)
        {
            bool IsNumber = int.TryParse(Year, out int year);
            if (!IsNumber || year < 1900 || year > 2200)
                MessageBox.Show("Please enter numbers from 1900 to 2200 only!");
            else
            {
                AddOrEditEventArgs albumData =
                   new(Album_Title, Artist, year, Txt_ImageURL.Text, Txt_Description.Text);

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
        }

        private void DataGridViewAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int rowClicked = dgv.CurrentRow.Index;
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
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}