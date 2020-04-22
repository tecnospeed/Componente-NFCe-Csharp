namespace Demo_NFe
{
    partial class frmPrincipal
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
            this.mmXmlRetorno = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEditarDanfe = new System.Windows.Forms.Button();
            this.btnPrever = new System.Windows.Forms.Button();
            this.btnInutilizar = new System.Windows.Forms.Button();
            this.btnConsultarNF = new System.Windows.Forms.Button();
            this.btnEnviarNF = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnIni = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtNumProtocolo = new System.Windows.Forms.TextBox();
            this.edtNumRecibo = new System.Windows.Forms.TextBox();
            this.edtIdNFe = new System.Windows.Forms.TextBox();
            this.edtCnpj = new System.Windows.Forms.TextBox();
            this.edtUf = new System.Windows.Forms.TextBox();
            this.cbCertificado = new System.Windows.Forms.ComboBox();
            this.btnEventos = new System.Windows.Forms.Button();
            this.dlgTx2 = new System.Windows.Forms.OpenFileDialog();
            this.btnConsultarRecibo = new System.Windows.Forms.Button();
            this.btnEnvioSincrono = new System.Windows.Forms.Button();
            this.btnGerarXMLDestinatario = new System.Windows.Forms.Button();
            this.mmXmlEnvio = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmXmlRetorno
            // 
            this.mmXmlRetorno.Location = new System.Drawing.Point(456, 338);
            this.mmXmlRetorno.Name = "mmXmlRetorno";
            this.mmXmlRetorno.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.mmXmlRetorno.Size = new System.Drawing.Size(471, 156);
            this.mmXmlRetorno.TabIndex = 0;
            this.mmXmlRetorno.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnviarEmail);
            this.groupBox1.Controls.Add(this.btnVisualizar);
            this.groupBox1.Controls.Add(this.btnExportarPDF);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnEditarDanfe);
            this.groupBox1.Controls.Add(this.btnPrever);
            this.groupBox1.Location = new System.Drawing.Point(243, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 220);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impressão";
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.Location = new System.Drawing.Point(17, 183);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(122, 27);
            this.btnEnviarEmail.TabIndex = 46;
            this.btnEnviarEmail.Text = "13. Enviar Email";
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(17, 152);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(122, 25);
            this.btnVisualizar.TabIndex = 21;
            this.btnVisualizar.Text = "12. Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Location = new System.Drawing.Point(17, 121);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(122, 25);
            this.btnExportarPDF.TabIndex = 20;
            this.btnExportarPDF.Text = "11. Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(17, 90);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(122, 25);
            this.btnImprimir.TabIndex = 19;
            this.btnImprimir.Text = "10. Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEditarDanfe
            // 
            this.btnEditarDanfe.Location = new System.Drawing.Point(17, 59);
            this.btnEditarDanfe.Name = "btnEditarDanfe";
            this.btnEditarDanfe.Size = new System.Drawing.Size(122, 25);
            this.btnEditarDanfe.TabIndex = 18;
            this.btnEditarDanfe.Text = "9. Editar Danfe";
            this.btnEditarDanfe.UseVisualStyleBackColor = true;
            this.btnEditarDanfe.Click += new System.EventHandler(this.btnEditarDanfe_Click);
            // 
            // btnPrever
            // 
            this.btnPrever.Location = new System.Drawing.Point(17, 28);
            this.btnPrever.Name = "btnPrever";
            this.btnPrever.Size = new System.Drawing.Size(122, 25);
            this.btnPrever.TabIndex = 17;
            this.btnPrever.Text = "Prever Danfe";
            this.btnPrever.UseVisualStyleBackColor = true;
            this.btnPrever.Click += new System.EventHandler(this.btnPrever_Click);
            // 
            // btnInutilizar
            // 
            this.btnInutilizar.Location = new System.Drawing.Point(9, 372);
            this.btnInutilizar.Name = "btnInutilizar";
            this.btnInutilizar.Size = new System.Drawing.Size(122, 25);
            this.btnInutilizar.TabIndex = 44;
            this.btnInutilizar.Text = "8. Inutilizar Numeração";
            this.btnInutilizar.UseVisualStyleBackColor = true;
            this.btnInutilizar.Click += new System.EventHandler(this.btnInutilizar_Click);
            // 
            // btnConsultarNF
            // 
            this.btnConsultarNF.Location = new System.Drawing.Point(9, 341);
            this.btnConsultarNF.Name = "btnConsultarNF";
            this.btnConsultarNF.Size = new System.Drawing.Size(122, 25);
            this.btnConsultarNF.TabIndex = 41;
            this.btnConsultarNF.Text = "6. Consultar NFCe";
            this.btnConsultarNF.UseVisualStyleBackColor = true;
            this.btnConsultarNF.Click += new System.EventHandler(this.btnConsultarNF_Click);
            // 
            // btnEnviarNF
            // 
            this.btnEnviarNF.Location = new System.Drawing.Point(9, 245);
            this.btnEnviarNF.Name = "btnEnviarNF";
            this.btnEnviarNF.Size = new System.Drawing.Size(122, 25);
            this.btnEnviarNF.TabIndex = 39;
            this.btnEnviarNF.Text = "4.1 Enviar NFCe";
            this.btnEnviarNF.UseVisualStyleBackColor = true;
            this.btnEnviarNF.Click += new System.EventHandler(this.btnEnviarNF_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(9, 214);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(122, 25);
            this.btnStatus.TabIndex = 36;
            this.btnStatus.Text = "1. Verificar Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnIni
            // 
            this.btnIni.Location = new System.Drawing.Point(10, 155);
            this.btnIni.Name = "btnIni";
            this.btnIni.Size = new System.Drawing.Size(122, 25);
            this.btnIni.TabIndex = 35;
            this.btnIni.Text = "Configurar Ini";
            this.btnIni.UseVisualStyleBackColor = true;
            this.btnIni.Click += new System.EventHandler(this.btnIni_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(10, 186);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(121, 22);
            this.btnLoadConfig.TabIndex = 34;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Número do Protocolo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Número do Recibo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "ID NFe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "CNPJ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "UF";
            // 
            // edtNumProtocolo
            // 
            this.edtNumProtocolo.Location = new System.Drawing.Point(216, 107);
            this.edtNumProtocolo.Name = "edtNumProtocolo";
            this.edtNumProtocolo.Size = new System.Drawing.Size(234, 20);
            this.edtNumProtocolo.TabIndex = 28;
            // 
            // edtNumRecibo
            // 
            this.edtNumRecibo.Location = new System.Drawing.Point(12, 107);
            this.edtNumRecibo.Name = "edtNumRecibo";
            this.edtNumRecibo.Size = new System.Drawing.Size(198, 20);
            this.edtNumRecibo.TabIndex = 27;
            // 
            // edtIdNFe
            // 
            this.edtIdNFe.Location = new System.Drawing.Point(166, 68);
            this.edtIdNFe.Name = "edtIdNFe";
            this.edtIdNFe.Size = new System.Drawing.Size(284, 20);
            this.edtIdNFe.TabIndex = 26;
            // 
            // edtCnpj
            // 
            this.edtCnpj.Location = new System.Drawing.Point(52, 68);
            this.edtCnpj.Name = "edtCnpj";
            this.edtCnpj.Size = new System.Drawing.Size(108, 20);
            this.edtCnpj.TabIndex = 25;
            // 
            // edtUf
            // 
            this.edtUf.Location = new System.Drawing.Point(12, 68);
            this.edtUf.Name = "edtUf";
            this.edtUf.Size = new System.Drawing.Size(34, 20);
            this.edtUf.TabIndex = 24;
            // 
            // cbCertificado
            // 
            this.cbCertificado.FormattingEnabled = true;
            this.cbCertificado.Location = new System.Drawing.Point(12, 24);
            this.cbCertificado.Name = "cbCertificado";
            this.cbCertificado.Size = new System.Drawing.Size(438, 21);
            this.cbCertificado.TabIndex = 23;
            this.cbCertificado.SelectedIndexChanged += new System.EventHandler(this.cbCertificado_SelectedIndexChanged);
            // 
            // btnEventos
            // 
            this.btnEventos.Location = new System.Drawing.Point(295, 412);
            this.btnEventos.Name = "btnEventos";
            this.btnEventos.Size = new System.Drawing.Size(155, 82);
            this.btnEventos.TabIndex = 46;
            this.btnEventos.Text = "Eventos NFCe";
            this.btnEventos.UseVisualStyleBackColor = true;
            this.btnEventos.Click += new System.EventHandler(this.btnEventos_Click);
            // 
            // dlgTx2
            // 
            this.dlgTx2.FileName = "openFileDialog1";
            // 
            // btnConsultarRecibo
            // 
            this.btnConsultarRecibo.Location = new System.Drawing.Point(9, 310);
            this.btnConsultarRecibo.Name = "btnConsultarRecibo";
            this.btnConsultarRecibo.Size = new System.Drawing.Size(122, 25);
            this.btnConsultarRecibo.TabIndex = 40;
            this.btnConsultarRecibo.Text = "5. Consultar Recibo";
            this.btnConsultarRecibo.UseVisualStyleBackColor = true;
            this.btnConsultarRecibo.Click += new System.EventHandler(this.btnConsultarRecibo_Click);
            // 
            // btnEnvioSincrono
            // 
            this.btnEnvioSincrono.Location = new System.Drawing.Point(9, 279);
            this.btnEnvioSincrono.Name = "btnEnvioSincrono";
            this.btnEnvioSincrono.Size = new System.Drawing.Size(122, 25);
            this.btnEnvioSincrono.TabIndex = 47;
            this.btnEnvioSincrono.Text = "4.2 Enviar Sincrono";
            this.btnEnvioSincrono.UseVisualStyleBackColor = true;
            this.btnEnvioSincrono.Click += new System.EventHandler(this.btnEnvioSincrono_Click);
            // 
            // btnGerarXMLDestinatario
            // 
            this.btnGerarXMLDestinatario.Location = new System.Drawing.Point(10, 412);
            this.btnGerarXMLDestinatario.Name = "btnGerarXMLDestinatario";
            this.btnGerarXMLDestinatario.Size = new System.Drawing.Size(263, 82);
            this.btnGerarXMLDestinatario.TabIndex = 48;
            this.btnGerarXMLDestinatario.Text = "Gerar XML Destinatario";
            this.btnGerarXMLDestinatario.UseVisualStyleBackColor = true;
            this.btnGerarXMLDestinatario.Click += new System.EventHandler(this.btnGerarXMLDestinatario_Click);
            // 
            // mmXmlEnvio
            // 
            this.mmXmlEnvio.Location = new System.Drawing.Point(456, 42);
            this.mmXmlEnvio.Name = "mmXmlEnvio";
            this.mmXmlEnvio.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.mmXmlEnvio.Size = new System.Drawing.Size(471, 274);
            this.mmXmlEnvio.TabIndex = 49;
            this.mmXmlEnvio.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Arquivo de Retorno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Arquivo de Envio";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 512);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mmXmlEnvio);
            this.Controls.Add(this.btnGerarXMLDestinatario);
            this.Controls.Add(this.btnEnvioSincrono);
            this.Controls.Add(this.btnEventos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInutilizar);
            this.Controls.Add(this.btnConsultarNF);
            this.Controls.Add(this.btnConsultarRecibo);
            this.Controls.Add(this.btnEnviarNF);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnIni);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtNumProtocolo);
            this.Controls.Add(this.edtNumRecibo);
            this.Controls.Add(this.edtIdNFe);
            this.Controls.Add(this.edtCnpj);
            this.Controls.Add(this.edtUf);
            this.Controls.Add(this.cbCertificado);
            this.Controls.Add(this.mmXmlRetorno);
            this.Name = "frmPrincipal";
            this.Text = "Demo NFCe";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox mmXmlRetorno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEditarDanfe;
        private System.Windows.Forms.Button btnInutilizar;
        private System.Windows.Forms.Button btnConsultarNF;
        private System.Windows.Forms.Button btnEnviarNF;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnIni;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtNumProtocolo;
        private System.Windows.Forms.TextBox edtNumRecibo;
        private System.Windows.Forms.TextBox edtIdNFe;
        private System.Windows.Forms.TextBox edtCnpj;
        private System.Windows.Forms.TextBox edtUf;
        private System.Windows.Forms.ComboBox cbCertificado;
        private System.Windows.Forms.Button btnPrever;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.Button btnEventos;
        private System.Windows.Forms.OpenFileDialog dlgTx2;
        private System.Windows.Forms.Button btnConsultarRecibo;
        private System.Windows.Forms.Button btnEnvioSincrono;
        private System.Windows.Forms.Button btnGerarXMLDestinatario;
        private System.Windows.Forms.RichTextBox mmXmlEnvio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

