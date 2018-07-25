using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace StockMarketPopupTickerApplication
{
    public partial class Form1 : Form
    {
        private bool closeFromNotifcationTray = false;
        private ConfigSettingsObject settings;
        private System.Timers.Timer popupTimer;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
            popupTimer = new System.Timers.Timer();
            popupTimer.Interval = settings.popupFrequencySeconds * 1000;
            popupTimer.Elapsed += PopupTimer_Elapsed;
            popupTimer.Start();
        }

        private void PopupTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ShowStockPrices();
        }

        #region Basic UI Events
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(closeFromNotifcationTray == true)
            {
                // Allow the close to happen, 
            }
            else
            {
                // Not closed from Exit button in notification tray, so just minimize.
                this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Defensive code to protect against recursive stack overflow
                // Seems that ShowInTaskbar true/false causes a SizeChange
                // Strange, but adding defensive code solves it.
                if (this.ShowInTaskbar == true)
                {
                    this.ShowInTaskbar = false;
                }
            }
            else
            {
                if (this.ShowInTaskbar == false)
                {
                    this.ShowInTaskbar = true;
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void exitStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFromNotifcationTray = true;
            Application.Exit();
        }

        private void openConfigStripMenu_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void showPricesNowMenuItem_Click(object sender, EventArgs e)
        {
            ShowStockPrices();
        }

        private void ShowStockPrices()
        {
            var data = GetStockPrices(settings);
            if (data.Count() >= 1)
            {
                Invoke(new MethodInvoker(() =>
                {
                    DynamicPopupForm dpop = new DynamicPopupForm(data, 5);
                    dpop.Show();
                }));
            }
        }

        #endregion

        #region config form events
        private void popupFreqNUD_ValueChanged(object sender, EventArgs e)
        {
            settings.popupFrequencySeconds = Convert.ToInt32(popupFreqNUD.Value);
            SaveSettingsToFile();
            popupTimer.Interval = settings.popupFrequencySeconds * 1000;
        }

        private void popupDurNUD_ValueChanged(object sender, EventArgs e)
        {
            settings.popupDurationSeconds = Convert.ToInt32(popupDurNUD.Value);
            SaveSettingsToFile();
        }

        private void tradingHoursCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.onlyPopupDuringTradingHours = tradingHoursCheckbox.Checked;
            SaveSettingsToFile();
        }

        private void removeStockButton_Click(object sender, EventArgs e)
        {
            if (this.watchedStockList.SelectedItem != null)
            {
                string stockToRemove = this.watchedStockList.SelectedItem.ToString();
                if (settings.watchedStock.IndexOf(stockToRemove) >= -1)
                {
                    settings.watchedStock.Remove(stockToRemove);
                    SaveSettingsToFile();
                    DrawListBasedOnStock();
                }
            }
        }

        private void addStockButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.addStockTextbox.Text) == false)
            {
                string stockToAdd = this.addStockTextbox.Text;
                if (settings.watchedStock.IndexOf(stockToAdd) >= 0)
                {
                    // Already added
                    Debug.WriteLine("Already added: " + stockToAdd);
                }
                else
                {
                    settings.watchedStock.Add(stockToAdd);
                    this.addStockTextbox.Text = "";
                    SaveSettingsToFile();
                    DrawListBasedOnStock();
                }
            }
        }

        #endregion

        private List<StockListObjectData> GetStockPrices(ConfigSettingsObject settings)
        {
            List<StockListObjectData> toReturn = new List<StockListObjectData>();
            // To array creates a copy of the list, so that alteration withing the UI
            // doesn't cause forloop iteration problems whilst altering
            foreach(var stock in settings.watchedStock.ToArray())
            {
                try
                {
                    StockListObjectData newData = IEXHelper.GetStockData(stock);
                    if (settings.onlyPopupDuringTradingHours == true)
                    {
                        if (newData.StockStockMarketOpen == true)
                        {
                            toReturn.Add(newData);
                        }
                    }
                    else
                    {
                        toReturn.Add(newData);
                    }
                }
                catch (Exception ex)
                {
                    if(ex.Message.StartsWith("Invalid status response:"))
                    {
                        //Invalid symbol likely
                        Debug.WriteLine(stock + ":" + ex.Message);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            return toReturn;
        }

        #region loading/savings settings
        /// <summary>
        /// Called upon startup to load from file
        /// </summary>
        private void LoadSettingsFromFile()
        {
            if(File.Exists("settingsConfig.xml"))
            {
                settings = DeSerializeObject<ConfigSettingsObject>("settingsConfig.xml");
            }
            else
            {
                // No settings config exists, so we will populate the settings with some default values
                settings = new ConfigSettingsObject();
                settings.onlyPopupDuringTradingHours = false;
                settings.popupDurationSeconds = 5;
                settings.popupFrequencySeconds = 60;
                settings.watchedStock = new List<string>() { "AAPL","TWTR","K","T" };
                SaveSettingsToFile();
            }
            // Now we have the settings file, we can have it load the settings into the config form.
            LoadSettingsIntoConfigForm();
            AttachListeners();
        }

        private void LoadSettingsIntoConfigForm()
        {
            this.popupDurNUD.Value = settings.popupDurationSeconds;
            this.popupFreqNUD.Value = settings.popupFrequencySeconds;
            this.tradingHoursCheckbox.Checked = settings.onlyPopupDuringTradingHours;
            this.addStockTextbox.Text = "";
            DrawListBasedOnStock();
        }

        /// <summary>
        /// This is called every time the configuration changes
        /// </summary>
        private void SaveSettingsToFile()
        {
            SerializeObject(settings, "settingsConfig.xml");
        }

        private void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with Saving settings to disk: " + ex.Message);
            }
        }

        private T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with opening settings from disk: " + ex.Message + " try deleting the settingsConfig.xml file");
            }

            return objectOut;
        }
        #endregion

        // We don't want the listeners firing whilst we are loading settings
        // so we attach the listeners AFTER the load of the values from settings
        private void AttachListeners()
        {
            this.popupFreqNUD.ValueChanged += new System.EventHandler(this.popupFreqNUD_ValueChanged);
            this.tradingHoursCheckbox.CheckedChanged += new System.EventHandler(this.tradingHoursCheckbox_CheckedChanged);
            this.popupDurNUD.ValueChanged += new System.EventHandler(this.popupDurNUD_ValueChanged);
        }

        private void DrawListBasedOnStock()
        {
            this.watchedStockList.Items.Clear();
            this.watchedStockList.Items.AddRange(settings.watchedStock.ToArray());
        }
    }
}
