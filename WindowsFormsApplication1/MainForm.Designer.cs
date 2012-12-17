namespace BankTest
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_MainTab = new System.Windows.Forms.TabControl();
            this.m_ImportTab = new System.Windows.Forms.TabPage();
            this.m_CategoriesTab = new System.Windows.Forms.TabPage();
            this.categoriesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankTestDataSet = new BankTest.BankTestDataSet();
            this.categoriesTableAdapter = new BankTest.BankTestDataSetTableAdapters.CategoriesTableAdapter();
            this.tableAdapterManager = new BankTest.BankTestDataSetTableAdapters.TableAdapterManager();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fortisImporterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_MainTab.SuspendLayout();
            this.m_CategoriesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fortisImporterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // m_MainTab
            // 
            this.m_MainTab.Controls.Add(this.m_ImportTab);
            this.m_MainTab.Controls.Add(this.m_CategoriesTab);
            this.m_MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MainTab.Location = new System.Drawing.Point(0, 0);
            this.m_MainTab.Name = "m_MainTab";
            this.m_MainTab.SelectedIndex = 0;
            this.m_MainTab.Size = new System.Drawing.Size(848, 401);
            this.m_MainTab.TabIndex = 0;
            // 
            // m_ImportTab
            // 
            this.m_ImportTab.Location = new System.Drawing.Point(4, 22);
            this.m_ImportTab.Name = "m_ImportTab";
            this.m_ImportTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_ImportTab.Size = new System.Drawing.Size(840, 375);
            this.m_ImportTab.TabIndex = 0;
            this.m_ImportTab.Text = "Import";
            this.m_ImportTab.UseVisualStyleBackColor = true;
            // 
            // m_CategoriesTab
            // 
            this.m_CategoriesTab.Controls.Add(this.checkBox1);
            this.m_CategoriesTab.Controls.Add(this.categoriesDataGridView);
            this.m_CategoriesTab.Location = new System.Drawing.Point(4, 22);
            this.m_CategoriesTab.Name = "m_CategoriesTab";
            this.m_CategoriesTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_CategoriesTab.Size = new System.Drawing.Size(840, 375);
            this.m_CategoriesTab.TabIndex = 1;
            this.m_CategoriesTab.Text = "Categories";
            this.m_CategoriesTab.UseVisualStyleBackColor = true;
            // 
            // categoriesDataGridView
            // 
            this.categoriesDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.categoriesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.categoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.categoriesDataGridView.DataSource = this.categoriesBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.categoriesDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.categoriesDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoriesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.categoriesDataGridView.Name = "categoriesDataGridView";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.categoriesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.categoriesDataGridView.Size = new System.Drawing.Size(343, 369);
            this.categoriesDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Color";
            this.dataGridViewTextBoxColumn3.HeaderText = "Color";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.bankTestDataSet;
            this.categoriesBindingSource.CurrentChanged += new System.EventHandler(this.categoriesBindingSource_CurrentChanged);
            // 
            // bankTestDataSet
            // 
            this.bankTestDataSet.DataSetName = "BankTestDataSet";
            this.bankTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoriesTableAdapter = this.categoriesTableAdapter;
            this.tableAdapterManager.TransactTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = BankTest.BankTestDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.fortisImporterBindingSource, "Dinges", true));
            this.checkBox1.Location = new System.Drawing.Point(489, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fortisImporterBindingSource
            // 
            this.fortisImporterBindingSource.DataSource = typeof(BankTest.FortisImporter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 401);
            this.Controls.Add(this.m_MainTab);
            this.Name = "MainForm";
            this.Text = "BankTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.m_MainTab.ResumeLayout(false);
            this.m_CategoriesTab.ResumeLayout(false);
            this.m_CategoriesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fortisImporterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_MainTab;
        private System.Windows.Forms.TabPage m_ImportTab;
        private System.Windows.Forms.TabPage m_CategoriesTab;
        private BankTestDataSet bankTestDataSet;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private BankTestDataSetTableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private BankTestDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView categoriesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource fortisImporterBindingSource;


    }
}

