namespace NewCompu
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
            this.VentanaP = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejerciciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpEjercicios = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tpGraficos2d = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VentanaP)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpEjercicios.SuspendLayout();
            this.SuspendLayout();
            // 
            // VentanaP
            // 
            this.VentanaP.BackColor = System.Drawing.SystemColors.HighlightText;
            this.VentanaP.Location = new System.Drawing.Point(1, 0);
            this.VentanaP.Name = "VentanaP";
            this.VentanaP.Size = new System.Drawing.Size(560, 440);
            this.VentanaP.TabIndex = 0;
            this.VentanaP.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(562, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(77, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejerciciosToolStripMenuItem,
            this.toolStripMenuItem1,
            this.limpiarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // ejerciciosToolStripMenuItem
            // 
            this.ejerciciosToolStripMenuItem.Name = "ejerciciosToolStripMenuItem";
            this.ejerciciosToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ejerciciosToolStripMenuItem.Text = "Ejercicios";
            this.ejerciciosToolStripMenuItem.Click += new System.EventHandler(this.ejerciciosToolStripMenuItem_Click);
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.limpiarToolStripMenuItem.Text = "Limpiar";
            this.limpiarToolStripMenuItem.Click += new System.EventHandler(this.limpiarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpEjercicios);
            this.tabControl.Controls.Add(this.tpGraficos2d);
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabControl.Location = new System.Drawing.Point(562, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(265, 415);
            this.tabControl.TabIndex = 1;
            // 
            // tpEjercicios
            // 
            this.tpEjercicios.BackColor = System.Drawing.Color.LightBlue;
            this.tpEjercicios.Controls.Add(this.button7);
            this.tpEjercicios.Controls.Add(this.button6);
            this.tpEjercicios.Controls.Add(this.button5);
            this.tpEjercicios.Controls.Add(this.button4);
            this.tpEjercicios.Controls.Add(this.button3);
            this.tpEjercicios.Controls.Add(this.button2);
            this.tpEjercicios.Controls.Add(this.button1);
            this.tpEjercicios.Location = new System.Drawing.Point(4, 22);
            this.tpEjercicios.Name = "tpEjercicios";
            this.tpEjercicios.Padding = new System.Windows.Forms.Padding(3);
            this.tpEjercicios.Size = new System.Drawing.Size(257, 389);
            this.tpEjercicios.TabIndex = 0;
            this.tpEjercicios.Text = "Ejercicios";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(165, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "pVector";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Tarea";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(84, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "TareaGrupal1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pinterpolado";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pixel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tpGraficos2d
            // 
            this.tpGraficos2d.Location = new System.Drawing.Point(4, 22);
            this.tpGraficos2d.Name = "tpGraficos2d";
            this.tpGraficos2d.Padding = new System.Windows.Forms.Padding(3);
            this.tpGraficos2d.Size = new System.Drawing.Size(257, 389);
            this.tpGraficos2d.TabIndex = 1;
            this.tpGraficos2d.Text = "Graficos2d";
            this.tpGraficos2d.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(165, 35);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Segmento";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Ejes";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Tarea2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(826, 483);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.VentanaP);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NewCompu";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VentanaP)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpEjercicios.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox VentanaP;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejerciciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpEjercicios;
        private System.Windows.Forms.TabPage tpGraficos2d;
        private System.Windows.Forms.ToolStripMenuItem limpiarToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button7;
    }
}

