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
            dgvAll = new DataGridView();
            btnLoadAllAlbums = new Button();
            btnSearchInAlbums = new Button();
            Txt_Search = new TextBox();
            AlbumImageBox = new PictureBox();
            panel1 = new Panel();
            label7 = new Label();
            cmbSearchContext = new ComboBox();
            GroupImageBox = new GroupBox();
            btnAddNewAlbum = new Button();
            groupAddOrEdit = new GroupBox();
            btnAbortEdit = new Button();
            lblID = new Label();
            label1 = new Label();
            lblRowCountStatus = new Label();
            btnSaveEdit = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtDescription = new TextBox();
            txtImageURL = new TextBox();
            txtYear = new TextBox();
            txtArtist = new TextBox();
            txtAlbumTitle = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlbumImageBox).BeginInit();
            panel1.SuspendLayout();
            GroupImageBox.SuspendLayout();
            groupAddOrEdit.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAll
            // 
            dgvAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAll.Location = new Point(12, 12);
            dgvAll.Name = "dgvAll";
            dgvAll.RowTemplate.Height = 25;
            dgvAll.Size = new Size(1160, 313);
            dgvAll.TabIndex = 0;
            dgvAll.CellClick += dgvAll_CellClick;
            dgvAll.CellDoubleClick += dgvAll_CellDoubleClick;
            // 
            // btnLoadAllAlbums
            // 
            btnLoadAllAlbums.AutoSize = true;
            btnLoadAllAlbums.BackColor = SystemColors.ActiveCaption;
            btnLoadAllAlbums.FlatStyle = FlatStyle.Flat;
            btnLoadAllAlbums.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadAllAlbums.Location = new Point(16, 21);
            btnLoadAllAlbums.Name = "btnLoadAllAlbums";
            btnLoadAllAlbums.Size = new Size(140, 33);
            btnLoadAllAlbums.TabIndex = 1;
            btnLoadAllAlbums.Text = "Load All Albums";
            btnLoadAllAlbums.UseVisualStyleBackColor = false;
            btnLoadAllAlbums.Click += btnLoadAllAlbums_Click;
            // 
            // btnSearchInAlbums
            // 
            btnSearchInAlbums.AutoSize = true;
            btnSearchInAlbums.BackColor = Color.OliveDrab;
            btnSearchInAlbums.FlatStyle = FlatStyle.Flat;
            btnSearchInAlbums.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearchInAlbums.Location = new Point(16, 70);
            btnSearchInAlbums.Name = "btnSearchInAlbums";
            btnSearchInAlbums.Size = new Size(185, 33);
            btnSearchInAlbums.TabIndex = 2;
            btnSearchInAlbums.Text = "Search In Albums";
            btnSearchInAlbums.UseVisualStyleBackColor = false;
            btnSearchInAlbums.Click += btnSearchInAlbums_Click;
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
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cmbSearchContext);
            panel1.Controls.Add(btnLoadAllAlbums);
            panel1.Controls.Add(btnSearchInAlbums);
            panel1.Controls.Add(Txt_Search);
            panel1.Location = new Point(404, 336);
            panel1.Name = "panel1";
            panel1.Size = new Size(768, 118);
            panel1.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(544, 56);
            label7.Name = "label7";
            label7.Size = new Size(105, 15);
            label7.TabIndex = 5;
            label7.Text = "Search in column:";
            // 
            // cmbSearchContext
            // 
            cmbSearchContext.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchContext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbSearchContext.FormattingEnabled = true;
            cmbSearchContext.Location = new Point(544, 74);
            cmbSearchContext.Name = "cmbSearchContext";
            cmbSearchContext.Size = new Size(217, 29);
            cmbSearchContext.TabIndex = 4;
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
            // btnAddNewAlbum
            // 
            btnAddNewAlbum.AutoSize = true;
            btnAddNewAlbum.BackColor = SystemColors.ButtonFace;
            btnAddNewAlbum.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddNewAlbum.ForeColor = Color.Blue;
            btnAddNewAlbum.Location = new Point(637, 135);
            btnAddNewAlbum.Name = "btnAddNewAlbum";
            btnAddNewAlbum.Size = new Size(125, 64);
            btnAddNewAlbum.TabIndex = 4;
            btnAddNewAlbum.Text = "Add Album";
            btnAddNewAlbum.UseVisualStyleBackColor = false;
            btnAddNewAlbum.Click += btnAddNewAlbum_Click;
            // 
            // groupAddOrEdit
            // 
            groupAddOrEdit.Controls.Add(btnAbortEdit);
            groupAddOrEdit.Controls.Add(lblID);
            groupAddOrEdit.Controls.Add(label1);
            groupAddOrEdit.Controls.Add(lblRowCountStatus);
            groupAddOrEdit.Controls.Add(btnSaveEdit);
            groupAddOrEdit.Controls.Add(label6);
            groupAddOrEdit.Controls.Add(label5);
            groupAddOrEdit.Controls.Add(label4);
            groupAddOrEdit.Controls.Add(label3);
            groupAddOrEdit.Controls.Add(label2);
            groupAddOrEdit.Controls.Add(txtDescription);
            groupAddOrEdit.Controls.Add(txtImageURL);
            groupAddOrEdit.Controls.Add(txtYear);
            groupAddOrEdit.Controls.Add(txtArtist);
            groupAddOrEdit.Controls.Add(txtAlbumTitle);
            groupAddOrEdit.Controls.Add(btnAddNewAlbum);
            groupAddOrEdit.Location = new Point(404, 471);
            groupAddOrEdit.Name = "groupAddOrEdit";
            groupAddOrEdit.Size = new Size(768, 241);
            groupAddOrEdit.TabIndex = 4;
            groupAddOrEdit.TabStop = false;
            groupAddOrEdit.Text = "Add or Edit an Album";
            // 
            // btnAbortEdit
            // 
            btnAbortEdit.ForeColor = Color.Red;
            btnAbortEdit.Location = new Point(307, 100);
            btnAbortEdit.Name = "btnAbortEdit";
            btnAbortEdit.Size = new Size(187, 29);
            btnAbortEdit.TabIndex = 21;
            btnAbortEdit.Text = "Abort Edit";
            btnAbortEdit.UseVisualStyleBackColor = true;
            btnAbortEdit.Click += btnAbortEdit_Click;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = SystemColors.GrayText;
            lblID.Location = new Point(115, 208);
            lblID.Name = "lblID";
            lblID.Size = new Size(18, 15);
            lblID.TabIndex = 20;
            lblID.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(17, 208);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 19;
            label1.Text = "ID:";
            // 
            // lblRowCountStatus
            // 
            lblRowCountStatus.AutoSize = true;
            lblRowCountStatus.Location = new Point(497, 208);
            lblRowCountStatus.Name = "lblRowCountStatus";
            lblRowCountStatus.Size = new Size(118, 15);
            lblRowCountStatus.TabIndex = 18;
            lblRowCountStatus.Text = "No album added yet.";
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveEdit.Location = new Point(637, 30);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(125, 64);
            btnSaveEdit.TabIndex = 17;
            btnSaveEdit.Text = "Commit Edit";
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Click += btnSaveEdit_Click;
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
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(115, 170);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(500, 29);
            txtDescription.TabIndex = 10;
            // 
            // txtImageURL
            // 
            txtImageURL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtImageURL.Location = new Point(115, 135);
            txtImageURL.Name = "txtImageURL";
            txtImageURL.ReadOnly = true;
            txtImageURL.Size = new Size(500, 29);
            txtImageURL.TabIndex = 9;
            // 
            // txtYear
            // 
            txtYear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtYear.Location = new Point(115, 100);
            txtYear.Name = "txtYear";
            txtYear.ReadOnly = true;
            txtYear.Size = new Size(100, 29);
            txtYear.TabIndex = 8;
            txtYear.KeyDown += txtYear_KeyDown;
            // 
            // txtArtist
            // 
            txtArtist.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtArtist.Location = new Point(115, 65);
            txtArtist.Name = "txtArtist";
            txtArtist.ReadOnly = true;
            txtArtist.Size = new Size(500, 29);
            txtArtist.TabIndex = 7;
            // 
            // txtAlbumTitle
            // 
            txtAlbumTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAlbumTitle.Location = new Point(115, 30);
            txtAlbumTitle.Name = "txtAlbumTitle";
            txtAlbumTitle.ReadOnly = true;
            txtAlbumTitle.Size = new Size(500, 29);
            txtAlbumTitle.TabIndex = 6;
            // 
            // MusicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 739);
            Controls.Add(groupAddOrEdit);
            Controls.Add(GroupImageBox);
            Controls.Add(panel1);
            Controls.Add(dgvAll);
            Name = "MusicForm";
            Text = "Music App";
            Load += MusicForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlbumImageBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            GroupImageBox.ResumeLayout(false);
            groupAddOrEdit.ResumeLayout(false);
            groupAddOrEdit.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAll;
        private Button btnLoadAllAlbums;
        private Button btnSearchInAlbums;
        private TextBox Txt_Search;
        private PictureBox AlbumImageBox;
        private Panel panel1;
        private GroupBox GroupImageBox;
        private GroupBox groupAddOrEdit;
        private Button btnAddNewAlbum;
        private TextBox txtArtist;
        private TextBox txtAlbumTitle;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtDescription;
        private TextBox txtImageURL;
        private TextBox txtYear;
        private Button btnSaveEdit;
        private Label lblRowCountStatus;
        private Label lblID;
        private Label label1;
        private Button btnAbortEdit;
        private ComboBox cmbSearchContext;
        private Label label7;
    }
}