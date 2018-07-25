namespace StockMarketPopupTickerApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openConfigStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showPricesNowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchedStockList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.removeStockButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addStockTextbox = new System.Windows.Forms.TextBox();
            this.addStockButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.popupFreqNUD = new System.Windows.Forms.NumericUpDown();
            this.tradingHoursCheckbox = new System.Windows.Forms.CheckBox();
            this.popupDurNUD = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupFreqNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDurNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Stock Market Popup Ticker Application";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigStripMenu,
            this.showPricesNowMenuItem,
            this.exitStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 70);
            // 
            // openConfigStripMenu
            // 
            this.openConfigStripMenu.Name = "openConfigStripMenu";
            this.openConfigStripMenu.Size = new System.Drawing.Size(165, 22);
            this.openConfigStripMenu.Text = "Open Config";
            this.openConfigStripMenu.Click += new System.EventHandler(this.openConfigStripMenu_Click);
            // 
            // showPricesNowMenuItem
            // 
            this.showPricesNowMenuItem.Name = "showPricesNowMenuItem";
            this.showPricesNowMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showPricesNowMenuItem.Text = "Show Prices Now";
            this.showPricesNowMenuItem.Click += new System.EventHandler(this.showPricesNowMenuItem_Click);
            // 
            // exitStripMenuItem
            // 
            this.exitStripMenuItem.Name = "exitStripMenuItem";
            this.exitStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitStripMenuItem.Text = "Exit";
            this.exitStripMenuItem.Click += new System.EventHandler(this.exitStripMenuItem_Click);
            // 
            // watchedStockList
            // 
            this.watchedStockList.FormattingEnabled = true;
            this.watchedStockList.Location = new System.Drawing.Point(101, 13);
            this.watchedStockList.Name = "watchedStockList";
            this.watchedStockList.Size = new System.Drawing.Size(220, 95);
            this.watchedStockList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Watched Stock";
            // 
            // removeStockButton
            // 
            this.removeStockButton.Location = new System.Drawing.Point(328, 13);
            this.removeStockButton.Name = "removeStockButton";
            this.removeStockButton.Size = new System.Drawing.Size(114, 23);
            this.removeStockButton.TabIndex = 3;
            this.removeStockButton.Text = "Remove Stock";
            this.removeStockButton.UseVisualStyleBackColor = true;
            this.removeStockButton.Click += new System.EventHandler(this.removeStockButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Add Stock";
            // 
            // addStockTextbox
            // 
            this.addStockTextbox.Location = new System.Drawing.Point(101, 114);
            this.addStockTextbox.Name = "addStockTextbox";
            this.addStockTextbox.Size = new System.Drawing.Size(220, 20);
            this.addStockTextbox.TabIndex = 5;
            // 
            // addStockButton
            // 
            this.addStockButton.Location = new System.Drawing.Point(327, 111);
            this.addStockButton.Name = "addStockButton";
            this.addStockButton.Size = new System.Drawing.Size(114, 23);
            this.addStockButton.TabIndex = 6;
            this.addStockButton.Text = "Add Stock";
            this.addStockButton.UseVisualStyleBackColor = true;
            this.addStockButton.Click += new System.EventHandler(this.addStockButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Frequency Of Popup ( seconds )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Duration of popup ( seconds )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 9;
            // 
            // popupFreqNUD
            // 
            this.popupFreqNUD.Location = new System.Drawing.Point(178, 154);
            this.popupFreqNUD.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.popupFreqNUD.Name = "popupFreqNUD";
            this.popupFreqNUD.Size = new System.Drawing.Size(120, 20);
            this.popupFreqNUD.TabIndex = 10;
            // 
            // tradingHoursCheckbox
            // 
            this.tradingHoursCheckbox.AutoSize = true;
            this.tradingHoursCheckbox.Location = new System.Drawing.Point(19, 228);
            this.tradingHoursCheckbox.Name = "tradingHoursCheckbox";
            this.tradingHoursCheckbox.Size = new System.Drawing.Size(171, 17);
            this.tradingHoursCheckbox.TabIndex = 11;
            this.tradingHoursCheckbox.Text = "Only show during trading hours";
            this.tradingHoursCheckbox.UseVisualStyleBackColor = true;
            // 
            // popupDurNUD
            // 
            this.popupDurNUD.Location = new System.Drawing.Point(178, 191);
            this.popupDurNUD.Name = "popupDurNUD";
            this.popupDurNUD.Size = new System.Drawing.Size(120, 20);
            this.popupDurNUD.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 274);
            this.Controls.Add(this.popupDurNUD);
            this.Controls.Add(this.tradingHoursCheckbox);
            this.Controls.Add(this.popupFreqNUD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addStockButton);
            this.Controls.Add(this.addStockTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeStockButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.watchedStockList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Stock Market Popup Ticket Config";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupFreqNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDurNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openConfigStripMenu;
        private System.Windows.Forms.ToolStripMenuItem showPricesNowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitStripMenuItem;
        private System.Windows.Forms.ListBox watchedStockList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeStockButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addStockTextbox;
        private System.Windows.Forms.Button addStockButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown popupFreqNUD;
        private System.Windows.Forms.CheckBox tradingHoursCheckbox;
        private System.Windows.Forms.NumericUpDown popupDurNUD;
    }
}

