namespace Compu
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ViewPort = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bVector = new System.Windows.Forms.Button();
            this.bVector2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnSgInt = new System.Windows.Forms.Button();
            this.btnSegColor = new System.Windows.Forms.Button();
            this.btnSegInt3 = new System.Windows.Forms.Button();
            this.btnCirInt = new System.Windows.Forms.Button();
            this.btnCirColor = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbrepaso = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblarea1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblarea2 = new System.Windows.Forms.Label();
            this.lblperimetro = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPort)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewPort
            // 
            this.ViewPort.BackColor = System.Drawing.Color.White;
            this.ViewPort.Location = new System.Drawing.Point(0, 0);
            this.ViewPort.Name = "ViewPort";
            this.ViewPort.Size = new System.Drawing.Size(600, 400);
            this.ViewPort.TabIndex = 0;
            this.ViewPort.TabStop = false;
            this.ViewPort.Click += new System.EventHandler(this.ViewPort_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "pixel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(616, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "dos colores";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(616, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "interpolar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(616, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 36);
            this.button4.TabIndex = 4;
            this.button4.Text = "interpolar 3 colores";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bVector
            // 
            this.bVector.Location = new System.Drawing.Point(616, 202);
            this.bVector.Name = "bVector";
            this.bVector.Size = new System.Drawing.Size(75, 23);
            this.bVector.TabIndex = 5;
            this.bVector.Text = "Vector";
            this.bVector.UseVisualStyleBackColor = true;
            this.bVector.Click += new System.EventHandler(this.bVector_Click);
            // 
            // bVector2
            // 
            this.bVector2.Location = new System.Drawing.Point(616, 243);
            this.bVector2.Name = "bVector2";
            this.bVector2.Size = new System.Drawing.Size(75, 23);
            this.bVector2.TabIndex = 6;
            this.bVector2.Text = "Vector1";
            this.bVector2.UseVisualStyleBackColor = true;
            this.bVector2.Click += new System.EventHandler(this.bVector2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(616, 287);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "circunferencia";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(616, 329);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Lazo";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(616, 358);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Hipociclo";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(616, 387);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Segmento";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(502, 409);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "figuras";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnSgInt
            // 
            this.btnSgInt.Location = new System.Drawing.Point(734, 26);
            this.btnSgInt.Name = "btnSgInt";
            this.btnSgInt.Size = new System.Drawing.Size(75, 38);
            this.btnSgInt.TabIndex = 12;
            this.btnSgInt.Text = "Segmento Interpolado";
            this.btnSgInt.UseVisualStyleBackColor = true;
            this.btnSgInt.Click += new System.EventHandler(this.btnSgInt_Click);
            // 
            // btnSegColor
            // 
            this.btnSegColor.Location = new System.Drawing.Point(734, 70);
            this.btnSegColor.Name = "btnSegColor";
            this.btnSegColor.Size = new System.Drawing.Size(75, 38);
            this.btnSegColor.TabIndex = 13;
            this.btnSegColor.Text = "Segmento 2 Colores";
            this.btnSegColor.UseVisualStyleBackColor = true;
            this.btnSegColor.Click += new System.EventHandler(this.btnSegColor_Click);
            // 
            // btnSegInt3
            // 
            this.btnSegInt3.Location = new System.Drawing.Point(722, 114);
            this.btnSegInt3.Name = "btnSegInt3";
            this.btnSegInt3.Size = new System.Drawing.Size(87, 38);
            this.btnSegInt3.TabIndex = 14;
            this.btnSegInt3.Text = "Segmento Interpolado 3";
            this.btnSegInt3.UseVisualStyleBackColor = true;
            this.btnSegInt3.Click += new System.EventHandler(this.btnSegInt3_Click);
            // 
            // btnCirInt
            // 
            this.btnCirInt.Location = new System.Drawing.Point(722, 158);
            this.btnCirInt.Name = "btnCirInt";
            this.btnCirInt.Size = new System.Drawing.Size(87, 40);
            this.btnCirInt.TabIndex = 15;
            this.btnCirInt.Text = "Circunferencia Interpolado";
            this.btnCirInt.UseVisualStyleBackColor = true;
            this.btnCirInt.Click += new System.EventHandler(this.btnCirInt_Click);
            // 
            // btnCirColor
            // 
            this.btnCirColor.Location = new System.Drawing.Point(722, 204);
            this.btnCirColor.Name = "btnCirColor";
            this.btnCirColor.Size = new System.Drawing.Size(87, 38);
            this.btnCirColor.TabIndex = 16;
            this.btnCirColor.Text = "Circunferencia 2 Colores";
            this.btnCirColor.UseVisualStyleBackColor = true;
            this.btnCirColor.Click += new System.EventHandler(this.btnCirColor_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(722, 248);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 38);
            this.button10.TabIndex = 17;
            this.button10.Text = "Circunferencia Interpolado 3";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(722, 292);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(87, 38);
            this.button11.TabIndex = 18;
            this.button11.Text = "Repaso";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(697, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "REPASO";
            // 
            // cbrepaso
            // 
            this.cbrepaso.FormattingEnabled = true;
            this.cbrepaso.Items.AddRange(new object[] {
            "Bisectriz",
            "Mediatriz",
            "Tangente a la circunferencia",
            "cono",
            "Letra d",
            "letra teta"});
            this.cbrepaso.Location = new System.Drawing.Point(697, 360);
            this.cbrepaso.Name = "cbrepaso";
            this.cbrepaso.Size = new System.Drawing.Size(121, 21);
            this.cbrepaso.TabIndex = 20;
            this.cbrepaso.SelectedIndexChanged += new System.EventHandler(this.cbrepaso_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(709, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Area1";
            // 
            // lblarea1
            // 
            this.lblarea1.AutoSize = true;
            this.lblarea1.Location = new System.Drawing.Point(761, 387);
            this.lblarea1.Name = "lblarea1";
            this.lblarea1.Size = new System.Drawing.Size(35, 13);
            this.lblarea1.TabIndex = 22;
            this.lblarea1.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Area2";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblarea2
            // 
            this.lblarea2.AutoSize = true;
            this.lblarea2.Location = new System.Drawing.Point(761, 409);
            this.lblarea2.Name = "lblarea2";
            this.lblarea2.Size = new System.Drawing.Size(35, 13);
            this.lblarea2.TabIndex = 24;
            this.lblarea2.Text = "label5";
            // 
            // lblperimetro
            // 
            this.lblperimetro.AutoSize = true;
            this.lblperimetro.Location = new System.Drawing.Point(765, 431);
            this.lblperimetro.Name = "lblperimetro";
            this.lblperimetro.Size = new System.Drawing.Size(35, 13);
            this.lblperimetro.TabIndex = 26;
            this.lblperimetro.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(713, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Perimetro";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(375, 408);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 27;
            this.button12.Text = "Prueba";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 463);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.lblperimetro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblarea2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblarea1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbrepaso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnCirColor);
            this.Controls.Add(this.btnCirInt);
            this.Controls.Add(this.btnSegInt3);
            this.Controls.Add(this.btnSegColor);
            this.Controls.Add(this.btnSgInt);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.bVector2);
            this.Controls.Add(this.bVector);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ViewPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ViewPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bVector;
        private System.Windows.Forms.Button bVector2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnSgInt;
        private System.Windows.Forms.Button btnSegColor;
        private System.Windows.Forms.Button btnSegInt3;
        private System.Windows.Forms.Button btnCirInt;
        private System.Windows.Forms.Button btnCirColor;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbrepaso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblarea1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblarea2;
        private System.Windows.Forms.Label lblperimetro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button12;
    }
}

