using System.Drawing;
using System.Windows.Forms;

namespace Lab9_Parallelism
{
    partial class AppForm
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
        Label speedLabel;
        Label cntLabel;
        TextBox speedTB;
        TextBox cntTB;
        private void InitializeComponent()
        {
            speedLabel = new Label();
            cntLabel = new Label();
            speedTB = new TextBox();
            cntTB = new TextBox();

            speedLabel.Text = "Задержка убегания: ";
            speedLabel.Size = new Size(150, 20);
            speedLabel.AutoSize = false;
            speedLabel.Location = new Point(260, 20);

            speedTB.Text = "25";
            speedTB.Location = new Point(410, 20);
            speedTB.Size = new Size(50, 20);
            speedTB.TabStop = false;

            cntLabel.Text = "Количество кнопок:";
            cntLabel.Size = new Size(150, 20);
            cntLabel.AutoSize = false;
            cntLabel.Location = new Point(480, 20);

            cntTB.Text = "5";
            cntTB.Location = new Point(630, 20);
            cntTB.Size = new Size(50, 20);
            cntTB.TabStop = false;

            cntTB.TextChanged += new System.EventHandler(CntChanged);
            speedTB.TextChanged += new System.EventHandler(SpeedChanged);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.MaximizeBox = false;
            this.Text = "AppForm";           
            this.Controls.Add(speedLabel);
            this.Controls.Add(speedTB);
            this.Controls.Add(cntLabel);
            this.Controls.Add(cntTB);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        #endregion
    }
}