using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace StockMarketPopupTickerApplication
{
    public class DynamicPopupForm : PopupForm
    {
        int secondsToDisplayFor = 5;
        System.Timers.Timer timer;
        public DynamicPopupForm(List<StockListObjectData> data, int secondsToDisplayFor)
        {
            // record the working area of the screen before doing any control re-sizes
            // The Working area is determined before the this.ClientSize adjustment
            // Otherwise it has been shown to show too much when only showing one stock
            // Bug/Unexplained behaviour
            Rectangle workingArea = Screen.GetWorkingArea(this);

            Size sizeOfContent = BuildStockListUI(data);
            //  + 4 is for the 2 pixels padding
            // + 10 is for room for X button.

            AddCloseButton(sizeOfContent.Width);
            this.ClientSize = new System.Drawing.Size(sizeOfContent.Width + 14, sizeOfContent.Height + 4);
            this.TopMost = true;

            // Move it to bottom right hand corner of screen.
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            this.secondsToDisplayFor = secondsToDisplayFor;
            this.Shown += DynamicPopupForm_Shown;

        }

        private void DynamicPopupForm_Shown(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = secondsToDisplayFor * 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            this.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                this.Close();
            });
        }

        private void AddCloseButton(int currentWidth)
        {
            var closeLabel = new System.Windows.Forms.Label();
            closeLabel.Text = "X";
            closeLabel.ForeColor = System.Drawing.Color.Gray;
            closeLabel.AutoSize = true;
            closeLabel.Size = new System.Drawing.Size(10, 10);
            closeLabel.Location = new System.Drawing.Point(currentWidth, 0);

            closeLabel.Click += CloseLabel_Click;

            this.Controls.Add(closeLabel);
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        private Size BuildStockListUI(List<StockListObjectData> data)
        {
            // 2 pixels in, just to have a slight padding
            int xlocation = 2;
            int ylocation = 2;

            int contentHeight = 0;
            int contentWidth = 0;

            // Dynamically add controls to the form
            foreach(var stockData in data)
            {
                var stockTicker = new System.Windows.Forms.Label();
                stockTicker.AutoSize = true;
                stockTicker.Size = new System.Drawing.Size(100, 15);
                stockTicker.Name = "label" + stockData.StockName;
                stockTicker.Text = stockData.StockName;
                stockTicker.Location = new System.Drawing.Point(xlocation, ylocation);
                stockTicker.ForeColor = System.Drawing.Color.White;                

                this.Controls.Add(stockTicker);

                var percentageLabel = new System.Windows.Forms.Label();
                percentageLabel.AutoSize = true;
                percentageLabel.Size = new System.Drawing.Size(100, 15);
                percentageLabel.Name = "labelPercent" + stockData.StockName;
                percentageLabel.Text = stockData.PercentageChange.ToString("0.00") + "%";
                percentageLabel.Location = new System.Drawing.Point(xlocation+100, ylocation);

                // Change percentage based on plus mins or equal
                if (stockData.PercentageChange > 0)
                {
                    percentageLabel.ForeColor = System.Drawing.Color.Green;
                    percentageLabel.Text = "+" + percentageLabel.Text;
                }
                else if (stockData.PercentageChange < 0)
                {
                    percentageLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    percentageLabel.ForeColor = System.Drawing.Color.Gray;
                }

                this.Controls.Add(percentageLabel);            

                ylocation += 15;

                contentWidth = 200;
                contentHeight += 15;

            }
            return new System.Drawing.Size(contentWidth, contentHeight);
        }
    }
}
