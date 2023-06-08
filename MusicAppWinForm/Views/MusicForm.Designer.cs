namespace PresentationLayer
{
    partial class MusicForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewAll = new DataGridView();
            Btn_LoadAllAlbums = new Button();
            Btn_SearchInAlbums = new Button();
            Txt_Search = new TextBox();
            AlbumImageBox = new PictureBox();
            panel1 = new Panel();
            Btn_LoadSelected = new Button();
            GroupImageBox = new GroupBox();
            Btn_AddNewAlbum = new Button();
            groupBox1 = new GroupBox();
            Lbl_AddSuccess = new Label();
            Btn_SaveEdit = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Txt_Description = new TextBox();
            Txt_ImageURL = new TextBox();
            Txt_Year = new TextBox();
            Txt_Artist = new TextBox();
            Txt_AlbumTitle = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DataGridViewAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlbumImageBox).BeginInit();
            panel1.SuspendLayout();
            GroupImageBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridViewAll
            // 
            DataGridViewAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DataGridViewAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewAll.Location = new Point(12, 12);
            DataGridViewAll.Name = "DataGridViewAll";
            DataGridViewAll.RowTemplate.Height = 25;
            DataGridViewAll.Size = new Size(1160, 313);
            DataGridViewAll.TabIndex = 0;
            DataGridViewAll.CellClick += DataGridViewAll_CellClick;
            // 
            // Btn_LoadAllAlbums
            // 
            Btn_LoadAllAlbums.AutoSize = true;
            Btn_LoadAllAlbums.BackColor = SystemColors.ActiveCaption;
            Btn_LoadAllAlbums.FlatStyle = FlatStyle.Flat;
            Btn_LoadAllAlbums.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_LoadAllAlbums.Location = new Point(16, 21);
            Btn_LoadAllAlbums.Name = "Btn_LoadAllAlbums";
            Btn_LoadAllAlbums.Size = new Size(140, 33);
            Btn_LoadAllAlbums.TabIndex = 1;
            Btn_LoadAllAlbums.Text = "Load All Albums";
            Btn_LoadAllAlbums.UseVisualStyleBackColor = false;
            Btn_LoadAllAlbums.Click += Btn_LoadAllAlbums_Click;
            // 
            // Btn_SearchInAlbums
            // 
            Btn_SearchInAlbums.AutoSize = true;
            Btn_SearchInAlbums.BackColor = Color.OliveDrab;
            Btn_SearchInAlbums.FlatStyle = FlatStyle.Flat;
            Btn_SearchInAlbums.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_SearchInAlbums.Location = new Point(16, 70);
            Btn_SearchInAlbums.Name = "Btn_SearchInAlbums";
            Btn_SearchInAlbums.Size = new Size(185, 33);
            Btn_SearchInAlbums.TabIndex = 2;
            Btn_SearchInAlbums.Text = "Search In Albums";
            Btn_SearchInAlbums.UseVisualStyleBackColor = false;
            Btn_SearchInAlbums.Click += Btn_SearchInAlbums_Click;
            // 
            // Txt_Search
            // 
            Txt_Search.BorderStyle = BorderStyle.FixedSingle;
            Txt_Search.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Search.Location = new Point(205, 74);
            Txt_Search.Margin = new Padding(1);
            Txt_Search.Name = "Txt_Search";
            Txt_Search.Size = new Size(335, 29);
            Txt_Search.TabIndex = 3;
            // 
            // AlbumImageBox
            // 
            AlbumImageBox.Location = new Point(16, 22);
            AlbumImageBox.Name = "AlbumImageBox";
            AlbumImageBox.Size = new Size(336, 336);
            AlbumImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            AlbumImageBox.TabIndex = 4;
            AlbumImageBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(Btn_LoadSelected);
            panel1.Controls.Add(Btn_LoadAllAlbums);
            panel1.Controls.Add(Btn_SearchInAlbums);
            panel1.Controls.Add(Txt_Search);
            panel1.Location = new Point(404, 336);
            panel1.Name = "panel1";
            panel1.Size = new Size(768, 118);
            panel1.TabIndex = 6;
            // 
            // Btn_LoadSelected
            // 
            Btn_LoadSelected.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_LoadSelected.Location = new Point(636, 40);
            Btn_LoadSelected.Name = "Btn_LoadSelected";
            Btn_LoadSelected.Size = new Size(125, 64);
            Btn_LoadSelected.TabIndex = 4;
            Btn_LoadSelected.Text = "Load Selected";
            Btn_LoadSelected.UseVisualStyleBackColor = true;
            // 
            // GroupImageBox
            // 
            GroupImageBox.BackColor = SystemColors.ControlLight;
            GroupImageBox.Controls.Add(AlbumImageBox);
            GroupImageBox.Location = new Point(12, 336);
            GroupImageBox.Name = "GroupImageBox";
            GroupImageBox.Size = new Size(372, 376);
            GroupImageBox.TabIndex = 7;
            GroupImageBox.TabStop = false;
            GroupImageBox.Text = "Album Image";
            // 
            // Btn_AddNewAlbum
            // 
            Btn_AddNewAlbum.AutoSize = true;
            Btn_AddNewAlbum.BackColor = SystemColors.ButtonFace;
            Btn_AddNewAlbum.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_AddNewAlbum.ForeColor = Color.Blue;
            Btn_AddNewAlbum.Location = new Point(637, 135);
            Btn_AddNewAlbum.Name = "Btn_AddNewAlbum";
            Btn_AddNewAlbum.Size = new Size(125, 64);
            Btn_AddNewAlbum.TabIndex = 4;
            Btn_AddNewAlbum.Text = "Add Album";
            Btn_AddNewAlbum.UseVisualStyleBackColor = false;
            Btn_AddNewAlbum.Click += Btn_AddNewAlbum_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Lbl_AddSuccess);
            groupBox1.Controls.Add(Btn_SaveEdit);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Txt_Description);
            groupBox1.Controls.Add(Txt_ImageURL);
            groupBox1.Controls.Add(Txt_Year);
            groupBox1.Controls.Add(Txt_Artist);
            groupBox1.Controls.Add(Txt_AlbumTitle);
            groupBox1.Controls.Add(Btn_AddNewAlbum);
            groupBox1.Location = new Point(404, 471);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(768, 241);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add or Edit an Album";
            // 
            // Lbl_AddSuccess
            // 
            Lbl_AddSuccess.AutoSize = true;
            Lbl_AddSuccess.Location = new Point(497, 208);
            Lbl_AddSuccess.Name = "Lbl_AddSuccess";
            Lbl_AddSuccess.Size = new Size(118, 15);
            Lbl_AddSuccess.TabIndex = 18;
            Lbl_AddSuccess.Text = "No album added yet.";
            // 
            // Btn_SaveEdit
            // 
            Btn_SaveEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_SaveEdit.Location = new Point(637, 30);
            Btn_SaveEdit.Name = "Btn_SaveEdit";
            Btn_SaveEdit.Size = new Size(125, 64);
            Btn_SaveEdit.TabIndex = 17;
            Btn_SaveEdit.Text = "Commit Edit";
            Btn_SaveEdit.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(17, 178);
            label6.Name = "label6";
            label6.Size = new Size(89, 21);
            label6.TabIndex = 16;
            label6.Text = "Description";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(17, 143);
            label5.Name = "label5";
            label5.Size = new Size(86, 21);
            label5.TabIndex = 15;
            label5.Text = "Image URL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 108);
            label4.Name = "label4";
            label4.Size = new Size(40, 21);
            label4.TabIndex = 14;
            label4.Text = "Year";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 73);
            label3.Name = "label3";
            label3.Size = new Size(47, 21);
            label3.TabIndex = 13;
            label3.Text = "Artist";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(17, 38);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 12;
            label2.Text = "Album Title";
            // 
            // Txt_Description
            // 
            Txt_Description.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Description.Location = new Point(115, 170);
            Txt_Description.Name = "Txt_Description";
            Txt_Description.Size = new Size(500, 29);
            Txt_Description.TabIndex = 10;
            // 
            // Txt_ImageURL
            // 
            Txt_ImageURL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_ImageURL.Location = new Point(115, 135);
            Txt_ImageURL.Name = "Txt_ImageURL";
            Txt_ImageURL.Size = new Size(500, 29);
            Txt_ImageURL.TabIndex = 9;
            // 
            // Txt_Year
            // 
            Txt_Year.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Year.Location = new Point(115, 100);
            Txt_Year.Name = "Txt_Year";
            Txt_Year.Size = new Size(100, 29);
            Txt_Year.TabIndex = 8;
            // 
            // Txt_Artist
            // 
            Txt_Artist.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Artist.Location = new Point(115, 65);
            Txt_Artist.Name = "Txt_Artist";
            Txt_Artist.Size = new Size(500, 29);
            Txt_Artist.TabIndex = 7;
            // 
            // Txt_AlbumTitle
            // 
            Txt_AlbumTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_AlbumTitle.Location = new Point(115, 30);
            Txt_AlbumTitle.Name = "Txt_AlbumTitle";
            Txt_AlbumTitle.Size = new Size(500, 29);
            Txt_AlbumTitle.TabIndex = 6;
            // 
            // MusicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 739);
            Controls.Add(groupBox1);
            Controls.Add(GroupImageBox);
            Controls.Add(panel1);
            Controls.Add(DataGridViewAll);
            Name = "MusicForm";
            Text = "Music App";
            ((System.ComponentModel.ISupportInitialize)DataGridViewAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlbumImageBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            GroupImageBox.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridViewAll;
        private Button Btn_LoadAllAlbums;
        private Button Btn_SearchInAlbums;
        private TextBox Txt_Search;
        private PictureBox AlbumImageBox;
        private Panel panel1;
        private GroupBox GroupImageBox;
        private GroupBox groupBox1;
        private Button Btn_AddNewAlbum;
        private TextBox Txt_Artist;
        private TextBox Txt_AlbumTitle;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox Txt_Description;
        private TextBox Txt_ImageURL;
        private TextBox Txt_Year;
        private Button Btn_SaveEdit;
        private Button Btn_LoadSelected;
        private Label Lbl_AddSuccess;
    }
}