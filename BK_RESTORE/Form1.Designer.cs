namespace BK_RESTORE
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.chbThamSo = new System.Windows.Forms.CheckBox();
			this.menuSaoLuu = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPhucHoi = new System.Windows.Forms.ToolStripMenuItem();
			this.menuThamSoPhucHoi = new System.Windows.Forms.ToolStripMenuItem();
			this.menuTaoDevice = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.dS = new BK_RESTORE.DS();
			this.databasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.databasesTableAdapter = new BK_RESTORE.DSTableAdapters.databasesTableAdapter();
			this.tableAdapterManager = new BK_RESTORE.DSTableAdapters.TableAdapterManager();
			this.databasesGridControl = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldatabase_id = new DevExpress.XtraGrid.Columns.GridColumn();
			this.position_backupBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.position_backupTableAdapter = new BK_RESTORE.DSTableAdapters.position_backupTableAdapter();
			this.position_backupGridControl = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colposition = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colname1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colbackup_start_date = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coluser_name = new DevExpress.XtraGrid.Columns.GridColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.databasesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.databasesGridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.position_backupBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.position_backupGridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// chbThamSo
			// 
			this.chbThamSo.AutoSize = true;
			this.chbThamSo.Location = new System.Drawing.Point(141, 5);
			this.chbThamSo.Name = "chbThamSo";
			this.chbThamSo.Size = new System.Drawing.Size(15, 14);
			this.chbThamSo.TabIndex = 1;
			this.chbThamSo.UseVisualStyleBackColor = true;
			// 
			// menuSaoLuu
			// 
			this.menuSaoLuu.Name = "menuSaoLuu";
			this.menuSaoLuu.Size = new System.Drawing.Size(61, 20);
			this.menuSaoLuu.Text = "Sao lưu ";
			this.menuSaoLuu.Click += new System.EventHandler(this.menuSaoLuu_Click);
			// 
			// menuPhucHoi
			// 
			this.menuPhucHoi.Name = "menuPhucHoi";
			this.menuPhucHoi.Size = new System.Drawing.Size(66, 20);
			this.menuPhucHoi.Text = "Phục hồi";
			// 
			// menuThamSoPhucHoi
			// 
			this.menuThamSoPhucHoi.Name = "menuThamSoPhucHoi";
			this.menuThamSoPhucHoi.Size = new System.Drawing.Size(206, 20);
			this.menuThamSoPhucHoi.Text = "     Tham số phục hồi theo thời gian";
			// 
			// menuTaoDevice
			// 
			this.menuTaoDevice.Name = "menuTaoDevice";
			this.menuTaoDevice.Size = new System.Drawing.Size(121, 20);
			this.menuTaoDevice.Text = "Tạo devices sao lưu";
			this.menuTaoDevice.Click += new System.EventHandler(this.menuTaoDevice_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSaoLuu,
            this.menuPhucHoi,
            this.menuThamSoPhucHoi,
            this.menuTaoDevice});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(952, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// dS
			// 
			this.dS.DataSetName = "DS";
			this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// databasesBindingSource
			// 
			this.databasesBindingSource.DataMember = "databases";
			this.databasesBindingSource.DataSource = this.dS;
			// 
			// databasesTableAdapter
			// 
			this.databasesTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.Connection = null;
			this.tableAdapterManager.UpdateOrder = BK_RESTORE.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// databasesGridControl
			// 
			this.databasesGridControl.DataSource = this.databasesBindingSource;
			this.databasesGridControl.Dock = System.Windows.Forms.DockStyle.Left;
			this.databasesGridControl.Location = new System.Drawing.Point(0, 24);
			this.databasesGridControl.MainView = this.gridView1;
			this.databasesGridControl.Name = "databasesGridControl";
			this.databasesGridControl.Size = new System.Drawing.Size(141, 426);
			this.databasesGridControl.TabIndex = 3;
			this.databasesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colname,
            this.coldatabase_id});
			this.gridView1.GridControl = this.databasesGridControl;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
			// 
			// colname
			// 
			this.colname.Caption = "Tên DB";
			this.colname.FieldName = "name";
			this.colname.Name = "colname";
			this.colname.OptionsColumn.AllowEdit = false;
			this.colname.Visible = true;
			this.colname.VisibleIndex = 0;
			// 
			// coldatabase_id
			// 
			this.coldatabase_id.FieldName = "database_id";
			this.coldatabase_id.Name = "coldatabase_id";
			// 
			// position_backupBindingSource
			// 
			this.position_backupBindingSource.DataMember = "position_backup";
			this.position_backupBindingSource.DataSource = this.dS;
			// 
			// position_backupTableAdapter
			// 
			this.position_backupTableAdapter.ClearBeforeFill = true;
			// 
			// position_backupGridControl
			// 
			this.position_backupGridControl.DataSource = this.position_backupBindingSource;
			this.position_backupGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.position_backupGridControl.Location = new System.Drawing.Point(141, 24);
			this.position_backupGridControl.MainView = this.gridView2;
			this.position_backupGridControl.Name = "position_backupGridControl";
			this.position_backupGridControl.Size = new System.Drawing.Size(811, 426);
			this.position_backupGridControl.TabIndex = 3;
			this.position_backupGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colposition,
            this.colname1,
            this.colbackup_start_date,
            this.coluser_name});
			this.gridView2.GridControl = this.position_backupGridControl;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsView.ShowGroupPanel = false;
			this.gridView2.Click += new System.EventHandler(this.gridView2_Click);
			// 
			// colposition
			// 
			this.colposition.Caption = "#";
			this.colposition.FieldName = "position";
			this.colposition.Name = "colposition";
			this.colposition.OptionsColumn.AllowEdit = false;
			this.colposition.Visible = true;
			this.colposition.VisibleIndex = 0;
			this.colposition.Width = 32;
			// 
			// colname1
			// 
			this.colname1.Caption = "Diễn giả";
			this.colname1.FieldName = "name";
			this.colname1.Name = "colname1";
			this.colname1.OptionsColumn.AllowEdit = false;
			this.colname1.Visible = true;
			this.colname1.VisibleIndex = 1;
			this.colname1.Width = 252;
			// 
			// colbackup_start_date
			// 
			this.colbackup_start_date.Caption = "Thời gian ";
			this.colbackup_start_date.DisplayFormat.FormatString = "G";
			this.colbackup_start_date.FieldName = "backup_start_date";
			this.colbackup_start_date.Name = "colbackup_start_date";
			this.colbackup_start_date.OptionsColumn.AllowEdit = false;
			this.colbackup_start_date.Visible = true;
			this.colbackup_start_date.VisibleIndex = 2;
			this.colbackup_start_date.Width = 252;
			// 
			// coluser_name
			// 
			this.coluser_name.Caption = "User";
			this.coluser_name.FieldName = "user_name";
			this.coluser_name.Name = "coluser_name";
			this.coluser_name.OptionsColumn.AllowEdit = false;
			this.coluser_name.Visible = true;
			this.coluser_name.VisibleIndex = 3;
			this.coluser_name.Width = 257;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(431, 224);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(952, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.position_backupGridControl);
			this.Controls.Add(this.databasesGridControl);
			this.Controls.Add(this.chbThamSo);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.databasesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.databasesGridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.position_backupBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.position_backupGridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox chbThamSo;
		private System.Windows.Forms.ToolStripMenuItem menuSaoLuu;
		private System.Windows.Forms.ToolStripMenuItem menuPhucHoi;
		private System.Windows.Forms.ToolStripMenuItem menuThamSoPhucHoi;
		private System.Windows.Forms.ToolStripMenuItem menuTaoDevice;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private DS dS;
		private System.Windows.Forms.BindingSource databasesBindingSource;
		private DSTableAdapters.databasesTableAdapter databasesTableAdapter;
		private DSTableAdapters.TableAdapterManager tableAdapterManager;
		private DevExpress.XtraGrid.GridControl databasesGridControl;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colname;
		private DevExpress.XtraGrid.Columns.GridColumn coldatabase_id;
		private System.Windows.Forms.BindingSource position_backupBindingSource;
		private DSTableAdapters.position_backupTableAdapter position_backupTableAdapter;
		private DevExpress.XtraGrid.GridControl position_backupGridControl;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn colposition;
		private DevExpress.XtraGrid.Columns.GridColumn colname1;
		private DevExpress.XtraGrid.Columns.GridColumn colbackup_start_date;
		private DevExpress.XtraGrid.Columns.GridColumn coluser_name;
		private System.Windows.Forms.Button button1;
	}
}

