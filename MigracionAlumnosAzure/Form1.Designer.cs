
namespace MigracionAlumnosAzure
{
    partial class Form1
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
            this.botonmigrar = new System.Windows.Forms.Button();
            this.labelmensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonmigrar
            // 
            this.botonmigrar.Location = new System.Drawing.Point(83, 43);
            this.botonmigrar.Name = "botonmigrar";
            this.botonmigrar.Size = new System.Drawing.Size(286, 85);
            this.botonmigrar.TabIndex = 0;
            this.botonmigrar.Text = "Migrar Alumnos Azure";
            this.botonmigrar.UseVisualStyleBackColor = true;
            this.botonmigrar.Click += new System.EventHandler(this.botonmigrar_Click);
            // 
            // labelmensaje
            // 
            this.labelmensaje.AutoSize = true;
            this.labelmensaje.Location = new System.Drawing.Point(38, 206);
            this.labelmensaje.Name = "labelmensaje";
            this.labelmensaje.Size = new System.Drawing.Size(68, 30);
            this.labelmensaje.TabIndex = 1;
            this.labelmensaje.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 343);
            this.Controls.Add(this.labelmensaje);
            this.Controls.Add(this.botonmigrar);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonmigrar;
        private System.Windows.Forms.Label labelmensaje;
    }
}

