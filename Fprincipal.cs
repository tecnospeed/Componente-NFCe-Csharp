using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NFCeX;
using NFCeDataSetX;
using System.Runtime.InteropServices;
using Ini;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace Demo_NFe
{
    public partial class frmPrincipal : Form
    {
        //******************************************************************************************************
        //
        //          Importação de funções externas
        //
        //******************************************************************************************************        

        //Carga de Dlls
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        XmlDocument xDoc = new XmlDocument();

        public static spdNFCeX spdNFCe = new spdNFCeX();
        private spdNFCeDataSetX spdNFCeDataSet = new spdNFCeDataSetX();

        private void CarregarConfig()
        {
            //Quando uilizado Loadconfig o caminho não pode ser relativo, assim é preferivel configurar estes via código.
            spdNFCe.DiretorioTemplates = Application.StartupPath + @"\Templates\";
            spdNFCe.DiretorioEsquemas = Application.StartupPath + @"\Esquemas\";
            spdNFCe.DiretorioLogErro = Application.StartupPath + @"\Log\";
            spdNFCe.DiretorioLog = Application.StartupPath + @"\Log\";
            spdNFCe.DiretorioXmlDestinatario = Application.StartupPath + @"\XMLDestinatario\";
            spdNFCe.ArquivoServidoresHom = Application.StartupPath + @"\NFCeServidoresHom.ini";
            spdNFCe.ArquivoServidoresProd = Application.StartupPath + @"\NFCeServidoresProd.ini";
            spdNFCe.ModeloDanfce = spdNFCe.DiretorioTemplates + @"danfce\retrato.rtm";
        }

        public frmPrincipal()
        {
            InitializeComponent();

            try
            {
                string[] vetor;
                vetor = spdNFCe.ListarCertificados("|").Split('|');//Método do componente que busca os certificados
                cbCertificado.Items.Clear();
                for (int i = 0; i < vetor.Length; i++)
                {
                    cbCertificado.Items.Add(vetor[i]);
                }
            }
            catch
            {
                MessageBox.Show("Nenhum certificado encontrado! Verifique o repositorio do windows.");
            }
        }

        public string ReadFile(string Arquivo, string extencao)
        {
            string xml = spdNFCe.DiretorioXmlDestinatario + Arquivo + extencao + ".xml";
            xDoc.Load(xml);
            return xDoc.InnerXml;
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            frmEventos novaform = new frmEventos();
            novaform.Show();
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            spdNFCe.ConfigurarSoftwareHouse("08187168000160", "");
            spdNFCe.LoadConfig(Application.StartupPath + @"\NFCeConfig.ini");
            CarregarConfig();
            cbCertificado.Text = spdNFCe.NomeCertificado;
            edtUf.Text = spdNFCe.UF;
            edtCnpj.Text = spdNFCe.CNPJ;

        }

        private void cbCertificado_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(Application.StartupPath + @"\NFCeConfig.ini");

            //Escreve o nome do certificado no arquivo ini
            ini.IniWriteValue("NFCE", "NomeCertificado", cbCertificado.SelectedItem.ToString());
        }

        private void btnIni_Click(object sender, EventArgs e)
        {
            // Metodo que abre o arquivo ini de configuração.
            Process.Start(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("\\", "//").Remove(0, 7) + "//nfceConfig.ini");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            mmXmlRetorno.Text = spdNFCe.StatusDoServico(); // Método do componente que verifica a conexão com o sefaz
        }

        private void btnEnviarNF_Click(object sender, EventArgs e)
        {
            mmXmlRetorno.Text = spdNFCe.EnviarNF("0001", mmXmlRetorno.Text, false);
            xDoc.LoadXml(mmXmlRetorno.Text);

            //Suprimir AV quando o xDoc não localiza a tag.
            try
            {
                edtNumRecibo.Text = xDoc.GetElementsByTagName("nRec").Item(0).InnerText;
            }
            catch
            {
            }
        }

        private void getRecibo(string xml)
        {
            xDoc.LoadXml(xml);

            //Suprimir AV quando o xDoc não localiza a tag.
            try
            {
                edtNumRecibo.Text = xDoc.GetElementsByTagName("nRec").Item(0).InnerText;
            }
            catch
            {
            }
        }

        private void getProtocolo(string xml)
        {
            mmXmlRetorno.Text = spdNFCe.ConsultarRecibo(edtNumRecibo.Text);
            xDoc.LoadXml(mmXmlRetorno.Text);

            //Suprimir AV quando o xDoc não localiza a tag.
            try
            {
                edtNumProtocolo.Text = xDoc.GetElementsByTagName("nProt").Item(0).InnerText;
            }
            catch
            {
            }
        }
        private void btnConsultarRecibo_Click(object sender, EventArgs e)
        {
            mmXmlRetorno.Text = spdNFCe.ConsultarRecibo(edtNumRecibo.Text);
            xDoc.LoadXml(mmXmlRetorno.Text);

            //Suprimir AV quando o xDoc não localiza a tag.
            try
            {
                edtNumProtocolo.Text = xDoc.GetElementsByTagName("nProt").Item(0).InnerText;
            }
            catch
            {
            }
        }

        private void btnConsultarNF_Click(object sender, EventArgs e)
        {
            mmXmlRetorno.Text = spdNFCe.ConsultarNF(edtIdNFe.Text);
            xDoc.LoadXml(mmXmlRetorno.Text);

            //Suprimir AV quando o xDoc não localiza a tag.
            try
            {
                edtNumRecibo.Text = xDoc.GetElementsByTagName("nProt").Item(0).InnerText;
            }
            catch
            {
            }
        }

        private void btnPrever_Click(object sender, EventArgs e)
        {
            spdNFCe.PreverDanfce(mmXmlRetorno.Text, "");
        }

        private void btnEditarDanfe_Click(object sender, EventArgs e)
        {
            if (edtIdNFe.Text != "")
            {
                spdNFCe.EditarModeloDanfce("00001", ReadFile(edtIdNFe.Text, "-nfce"), "");
            }
            else
            {
                spdNFCe.EditarModeloDanfce("00001", mmXmlRetorno.Text, "");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (edtIdNFe.Text != "")
            {
                spdNFCe.ImprimirDanfce("00001", ReadFile(edtIdNFe.Text, "-nfce"), "", "");
            }
            else
            {
                spdNFCe.ImprimirDanfce("00001", mmXmlRetorno.Text, "", "");
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (edtIdNFe.Text != "")
            {
                spdNFCe.ExportarDanfce("00001", ReadFile(edtIdNFe.Text, "-nfce"), "", 1, "");
            }
            else
            {
                spdNFCe.ExportarDanfce("00001", mmXmlRetorno.Text, "", 1, "");
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {

            if (edtIdNFe.Text != "")
            {
                spdNFCe.VisualizarDanfce("00001", ReadFile(edtIdNFe.Text, "-nfce"), "");
            }
            else
            {
                spdNFCe.VisualizarDanfce("00001", mmXmlRetorno.Text, "");
            }
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            spdNFCe.AnexarDAMFCEPDF = true;
            spdNFCe.EnviarNotaDestinatario(edtIdNFe.Text, "", "");
        }

        private void btnInutilizar_Click(object sender, EventArgs e)
        {
            string ano = Microsoft.VisualBasic.Interaction.InputBox("Inutilização de faixa NFe", "Ano", "15", -1, -1);
            string modelo = Microsoft.VisualBasic.Interaction.InputBox("Inutilização de faixa NFe", "Modelo", "55", -1, -1);
            string serie = Microsoft.VisualBasic.Interaction.InputBox("Inutilização de faixa NFe", "Serie", "1", -1, -1);
            string faixaIni = Microsoft.VisualBasic.Interaction.InputBox("Inutilização de faixa NFe", "Faixa Inicio", "1", -1, -1);
            string faixaFim = Microsoft.VisualBasic.Interaction.InputBox("Inutilização de faixa NFe", "Faixa Fim", "10", -1, -1);
            string justificativa = Microsoft.VisualBasic.Interaction.InputBox("Inutilização de faixa NFe", "Justificativa", "Teste de inutilização de faixa!", -1, -1);

            mmXmlRetorno.Text = spdNFCe.InutilizarNF("", ano, spdNFCe.CNPJ, modelo, serie, faixaIni, faixaFim, justificativa);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            spdNFCe.LoadConfig(Application.StartupPath + @"\NFCeConfig.ini");
            //CarregarConfig();
            cbCertificado.Text = spdNFCe.NomeCertificado;
            edtUf.Text = spdNFCe.UF;
            edtCnpj.Text = spdNFCe.CNPJ;
        }

        private void btnGerarXMLDestinatario_Click(object sender, EventArgs e)
        {
            string aLogEnvio = "";
            string aLogRec = "";
            dlgTx2.InitialDirectory = Application.StartupPath;
            dlgTx2.ShowDialog();
            aLogEnvio = dlgTx2.FileName;
            dlgTx2.ShowDialog();
            aLogRec = dlgTx2.FileName;
            spdNFCe.GerarXMLEnvioDestinatario(edtIdNFe.Text, aLogEnvio, aLogRec, "");
        }

        private void btnGerarXMLCancDest_Click(object sender, EventArgs e)
        {
            string aLogEnvio = "";
            string aLogRec = "";
            /* dlgTx2.InitialDirectory = Application.StartupPath;
            dlgTx2.ShowDialog();
            aLogEnvio = dlgTx2.FileName;
            dlgTx2.ShowDialog();*/
            aLogEnvio = dlgTx2.FileName;
            aLogRec = dlgTx2.FileName;
            spdNFCe.GerarXMLEnvioDestinatario(edtIdNFe.Text, aLogEnvio, aLogRec, "");
        }

        private void btnEnvioSincrono_Click(object sender, EventArgs e)
        {
            // Gerar XMl via DataSet
            gerarXml("102");

            //Assinar
            mmXmlEnvio.Text = spdNFCe.AssinarNota(mmXmlEnvio.Text);

            mmXmlRetorno.Text = spdNFCe.EnviarNFSincrono("00001", mmXmlEnvio.Text, false);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            mmXmlRetorno.Text = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now);
        }

        private void DadosDoNFe()
        {
            Random Rand = new Random();
            ////////////Dados da Nota Fiscal eletrônica///////////////
            spdNFCeDataSet.SetCampo("versao_A02=3.10");
            spdNFCeDataSet.SetCampo("Id_A03=");

            ////////////Identificação da Nota Fiscal eletrônica///////////////
            spdNFCeDataSet.SetCampo("cUF_B02=41");
            spdNFCeDataSet.SetCampo("cNF_B03=" + Convert.ToString(Rand.Next(11111111, 99999999)));
            spdNFCeDataSet.SetCampo("natOp_B04=VENDA DE MERCADORIA ADQ. DE TERCEIRO");
            spdNFCeDataSet.SetCampo("indPag_B05=0");
            spdNFCeDataSet.SetCampo("mod_B06=65");
            spdNFCeDataSet.SetCampo("serie_B07=" + Convert.ToString(Rand.Next(1, 999)));

            spdNFCeDataSet.SetCampo("nNF_B08=" + Convert.ToString(Rand.Next(1, 999999999)));
            spdNFCeDataSet.SetCampo("dhEmi_B09=" + String.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now) + "-03:00");
            spdNFCeDataSet.SetCampo("tpNF_B11=1");
            spdNFCeDataSet.SetCampo("idDest_B11a=1");
            spdNFCeDataSet.SetCampo("cMunFG_B12=4115200");

            spdNFCeDataSet.SetCampo("tpImp_B21=4");

            spdNFCeDataSet.SetCampo("tpEmis_B22=1");
            spdNFCeDataSet.SetCampo("cDV_B23=1");
            spdNFCeDataSet.SetCampo("tpAmb_B24=2");
            spdNFCeDataSet.SetCampo("finNFe_B25=1");
            spdNFCeDataSet.SetCampo("indFinal_B25a=1");
            spdNFCeDataSet.SetCampo("indPres_B25b=1");
            spdNFCeDataSet.SetCampo("procEmi_B26=0");
            spdNFCeDataSet.SetCampo("verProc_B27=5");
        }

        private void DadosDoEmitente()
        {
            ////////////Identificação do Emitente da Nota Fiscal eletrônica///////////////
            spdNFCeDataSet.SetCampo("CNPJ_C02=" + spdNFCe.CNPJ);
            spdNFCeDataSet.SetCampo("xNome_C03=ANTONIO ALBERTO CHAVES DE MOURA JUNIOR");
            spdNFCeDataSet.SetCampo("xFant_C04=SUPERMERCADO CARNAUBAIS");

            spdNFCeDataSet.SetCampo("xLgr_C06=RUA JOAO DOS SANTOS");
            spdNFCeDataSet.SetCampo("nro_C07=735");
            spdNFCeDataSet.SetCampo("xBairro_C09=CENTRO");
            spdNFCeDataSet.SetCampo("cMun_C10=2202307");
            spdNFCeDataSet.SetCampo("xMun_C11=Canto do Buriti");
            spdNFCeDataSet.SetCampo("UF_C12=" + spdNFCe.UF);
            spdNFCeDataSet.SetCampo("CEP_C13=64890000");
            spdNFCeDataSet.SetCampo("cPais_C14=1058");
            spdNFCeDataSet.SetCampo("xPais_C15=BRASIL");

            // spdNFCeDataSet.SetCampo("fone_C16=4430283749");
            spdNFCeDataSet.SetCampo("IE_C17=195697294");

            spdNFCeDataSet.SetCampo("CRT_C21=1");

        }

        private void DadosDoDestinatario()
        {
            ////////////Identificação do Destinatário///////////////
            spdNFCeDataSet.SetCampo("CPF_E03=81250814294");
            spdNFCeDataSet.SetCampo("xNome_E04=NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            spdNFCeDataSet.SetCampo("xLgr_E06=Rua Rui Barbosa");
            spdNFCeDataSet.SetCampo("nro_E07=897");
            spdNFCeDataSet.SetCampo("xCpl_E08=");
            spdNFCeDataSet.SetCampo("xBairro_E09=Zona 07");
            spdNFCeDataSet.SetCampo("cMun_E10=4115200");
            spdNFCeDataSet.SetCampo("xMun_E11=MARINGA");
            spdNFCeDataSet.SetCampo("UF_E12=PR");
            spdNFCeDataSet.SetCampo("CEP_E13=95700000");
            spdNFCeDataSet.SetCampo("cPais_E14=1058");
            spdNFCeDataSet.SetCampo("xPais_E15=BRASIL");
            spdNFCeDataSet.SetCampo("fone_E16=445555555");
            spdNFCeDataSet.SetCampo("indIEDest_E16a=9");
        }

        private void DadosDoItem(string codICMS)
        {
            spdNFCeDataSet.IncluirItem();
            ////////////Detalhamento de Produtos e Serviços da NF-e///////////////
            spdNFCeDataSet.SetCampo("nItem_H02=1");

            ////////////Produtos e Serviços da NF-e///////////////
            spdNFCeDataSet.SetCampo("cProd_I02=25");

            //O campo permanece, mas agora, quando não houver valor nele, deve-se informar o loteral SEM GTIN
            spdNFCeDataSet.SetCampo("cEAN_I03=7898106035513");

            spdNFCeDataSet.SetCampo("xProd_I04=NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            spdNFCeDataSet.SetCampo("NCM_I05=30043929");    //30043929
            spdNFCeDataSet.SetCampo("CFOP_I08=5102");
            spdNFCeDataSet.SetCampo("uCom_I09=CX");
            spdNFCeDataSet.SetCampo("qCom_I10=1.0000");
            spdNFCeDataSet.SetCampo("vUnCom_I10a=1.0000");
            spdNFCeDataSet.SetCampo("vProd_I11=1.00");

            //O campo permanece, mas agora, quando não houver valor nele, deve-se informar o loteral SEM GTIN
            spdNFCeDataSet.SetCampo("cEANTrib_I12=7898106035513");

            spdNFCeDataSet.SetCampo("uTrib_I13=CX");
            spdNFCeDataSet.SetCampo("qTrib_I14=1.0000");
            spdNFCeDataSet.SetCampo("vUnTrib_I14a=1.0000");
            spdNFCeDataSet.SetCampo("indTot_I17b=1");

            ////////////Tributos incidentes no Produto ou Serviço///////////////
            spdNFCeDataSet.SetCampo("vTotTrib_M02=1.00");


            ////////////ICMS///////////////            
            string cst = codICMS;
            switch (cst)
            {
                //////////// CSOSN PARA O SIMPLES NACIONAL /////////////// 
                case "101":
                    // Tributada pelo Simples Nacional com permissão de crédito.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=101");
                    spdNFCeDataSet.SetCampo("pCredSN_N29=0.00");
                    spdNFCeDataSet.SetCampo("vCredICMSSN_N30=0.00");

                    break;
                case "102":
                    // Tributada pelo Simples Nacional sem permissão de crédito.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=102");
                    break;
                case "103":
                    // Isenção do ICMS no Simples Nacional para faixa de receita bruta.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=103");
                    break;
                case "201":
                    // Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS por Substituição Tributária.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=201");
                    spdNFCeDataSet.SetCampo("modBCST_N18=5");
                    spdNFCeDataSet.SetCampo("pMVAST_N19=0.00");
                    spdNFCeDataSet.SetCampo("pRedBCST_N20=0.00");
                    spdNFCeDataSet.SetCampo("vBCST_N21=0.00");
                    spdNFCeDataSet.SetCampo("pICMSST_N22=0.00");
                    spdNFCeDataSet.SetCampo("vICMSST_N23=0.00");
                    spdNFCeDataSet.SetCampo("vBCFCPST_N23a=0.00");
                    spdNFCeDataSet.SetCampo("pFCPST_N23b=0.00");
                    spdNFCeDataSet.SetCampo("vFCPST_N23d=0.00");
                    spdNFCeDataSet.SetCampo("pCredSN_N29=0.00");
                    spdNFCeDataSet.SetCampo("vCredICMSSN_N30=0.00");
                    break;
                case "202":
                    // Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por Substituição Tributária.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=202");
                    spdNFCeDataSet.SetCampo("modBCST_N18=5");
                    spdNFCeDataSet.SetCampo("pMVAST_N19=0.00");
                    spdNFCeDataSet.SetCampo("pRedBCST_N20=0.00");
                    spdNFCeDataSet.SetCampo("vBCST_N21=0.00");
                    spdNFCeDataSet.SetCampo("pICMSST_N22=0.00");
                    spdNFCeDataSet.SetCampo("vICMSST_N23=0.00");
                    spdNFCeDataSet.SetCampo("vBCFCPST_N23a=0.00");
                    spdNFCeDataSet.SetCampo("pFCPST_N23b=0.00");
                    spdNFCeDataSet.SetCampo("vFCPST_N23d=0.00");
                    break;
                case "203":
                    // Isenção do ICMS nos Simples Nacional para faixa de receita bruta e com cobrança do ICMS por Substituição Tributária.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=203");
                    spdNFCeDataSet.SetCampo("modBCST_N18=5");
                    spdNFCeDataSet.SetCampo("pMVAST_N19=0.00");
                    spdNFCeDataSet.SetCampo("pRedBCST_N20=0.00");
                    spdNFCeDataSet.SetCampo("vBCST_N21=0.00");
                    spdNFCeDataSet.SetCampo("pICMSST_N22=0.00");
                    spdNFCeDataSet.SetCampo("vICMSST_N23=0.00");
                    spdNFCeDataSet.SetCampo("vBCFCPST_N23a=0.00");
                    spdNFCeDataSet.SetCampo("pFCPST_N23b=0.00");
                    spdNFCeDataSet.SetCampo("vFCPST_N23d=0.00");
                    break;
                case "300":
                    // Imune.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=300");
                    break;
                case "400":
                    // Não tributada pelo Simples Nacional.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=400");
                    break;
                case "500":
                    // ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=500");
                    spdNFCeDataSet.SetCampo("vBCSTRet_N26=0.00");
                    spdNFCeDataSet.SetCampo("pST_N26a=0.00");
                    spdNFCeDataSet.SetCampo("vICMSSTRet_N27=0.00");
                    spdNFCeDataSet.SetCampo("vBCFCPSTRet_N27a=0.00");
                    spdNFCeDataSet.SetCampo("pFCPSTRet_N27b=0.00");
                    spdNFCeDataSet.SetCampo("vFCPSTRet_N27d=0.00");
                    spdNFCeDataSet.SetCampo("pRedBCEfet_N34=0.00");
                    spdNFCeDataSet.SetCampo("vBCEfet_N35=0.00");
                    spdNFCeDataSet.SetCampo("pICMSEfet_N36=0.00");
                    spdNFCeDataSet.SetCampo("vICMSEfet_N37=0.00");
                    break;
                case "900":
                    // Outros.
                    spdNFCeDataSet.SetCampo("orig_N11=0");
                    spdNFCeDataSet.SetCampo("CSOSN_N12a=900");
                    spdNFCeDataSet.SetCampo("modBC_N13=5");
                    spdNFCeDataSet.SetCampo("vBC_N15=0.00");
                    spdNFCeDataSet.SetCampo("pRedBC_N14=0.00");
                    spdNFCeDataSet.SetCampo("pICMS_N16=0.00");
                    spdNFCeDataSet.SetCampo("vICMS_N17=0.00");
                    spdNFCeDataSet.SetCampo("modBCST_N18=0.00");
                    spdNFCeDataSet.SetCampo("pMVAST_N19=0.00");
                    spdNFCeDataSet.SetCampo("pRedBCST_N20=0.00");
                    spdNFCeDataSet.SetCampo("vBCST_N21=0.00");
                    spdNFCeDataSet.SetCampo("pICMSST_N22=0.00");
                    spdNFCeDataSet.SetCampo("vICMSST_N23=0.00");
                    spdNFCeDataSet.SetCampo("vBCFCPST_N23a=0.00");
                    spdNFCeDataSet.SetCampo("pFCPST_N23b=0.00");
                    spdNFCeDataSet.SetCampo("vFCPST_N23d=0.00");
                    spdNFCeDataSet.SetCampo("pCredSN_N29=0.00");
                    spdNFCeDataSet.SetCampo("vCredICMSSN_N30=0.00");
                    break;
            }

            ////////////PIS///////////////
            spdNFCeDataSet.SetCampo("CST_Q06=07");

            ////////////CONFINS///////////////
            spdNFCeDataSet.SetCampo("CST_S06=07");

            spdNFCeDataSet.SetCampo("infAdProd_V01=Teste | Teste");

            spdNFCeDataSet.SalvarItem();
        }

        private void DadosTotalizadores400()
        {
            spdNFCeDataSet.SetCampo("vBC_W03=0.00");
            spdNFCeDataSet.SetCampo("vICMS_W04=0.00");

            //campo novo
            spdNFCeDataSet.SetCampo("vFCP_W04h=0.00");

            spdNFCeDataSet.SetCampo("vICMSDeson_W04a=0.00");
            spdNFCeDataSet.SetCampo("vBCST_W05=0.00");
            spdNFCeDataSet.SetCampo("vST_W06=0.00");

            //campos novos
            spdNFCeDataSet.SetCampo("vFCPST_W06a=0.00");
            spdNFCeDataSet.SetCampo("vFCPSTRet_W06b=0.00");

            spdNFCeDataSet.SetCampo("vProd_W07=1.00");
            spdNFCeDataSet.SetCampo("vFrete_W08=0.00");
            spdNFCeDataSet.SetCampo("vSeg_W09=0.00");
            spdNFCeDataSet.SetCampo("vDesc_W10=0.00");
            spdNFCeDataSet.SetCampo("vII_W11=0.00");
            spdNFCeDataSet.SetCampo("vIPI_W12=0.00");

            //campo novo
            spdNFCeDataSet.SetCampo("vIPIDevol_W12a=0.00");

            spdNFCeDataSet.SetCampo("vPIS_W13=0.00");
            spdNFCeDataSet.SetCampo("vCOFINS_W14=0.00");
            spdNFCeDataSet.SetCampo("vOutro_W15=0.00");
            spdNFCeDataSet.SetCampo("vNF_W16=1.00");
            spdNFCeDataSet.SetCampo("vTotTrib_W16a=1.00");
        }

        private void DadosTransporte()
        {
            spdNFCeDataSet.SetCampo("modFrete_X02=9");
        }

        private void DadosAdicionais()
        {
            spdNFCeDataSet.SetCampo("infAdFisco_Z02=OBSERVACAO TESTE DA DANFE - FISCO  OBSERVACAO TESTE DA DANFE - FISCO");
            spdNFCeDataSet.SetCampo("infCpl_Z03=OBSERVACAO TESTE DA DANFE CONTRIBUINTE  OBSERVACAO TESTE DA DANFE CONTRIBUINTE");
        }

        private void DadosPagamento()
        {
            spdNFCeDataSet.IncluirParte("YA");
            spdNFCeDataSet.SetCampo("tPag_YA02=01");
            spdNFCeDataSet.SetCampo("vPag_YA03=0.50");
            spdNFCeDataSet.SalvarParte("YA");

            spdNFCeDataSet.IncluirParte("YA");
            spdNFCeDataSet.SetCampo("tPag_YA02=05");
            spdNFCeDataSet.SetCampo("vPag_YA03=0.50");
            spdNFCeDataSet.SalvarParte("YA");
        }


        //DadosDoNFe();
        //DadosDoEmitente();
        //DadosDoDestinatario();
        //DadosTotalizadores();
        //DadosDoItem();
        //DadosTransporte();
        //DadosAdicionais();
        //DadosPagamento();

        private void DadosDoNFe400()
        {
            Random Rand = new Random();
            ////////////Dados da Nota Fiscal eletrônica///////////////
            spdNFCeDataSet.SetCampo("versao_A02=4.00");
            spdNFCeDataSet.SetCampo("Id_A03=");

            ////////////Identificação da Nota Fiscal eletrônica///////////////
            spdNFCeDataSet.SetCampo("cUF_B02=22");
            spdNFCeDataSet.SetCampo("cNF_B03=" + Convert.ToString(Rand.Next(11111111, 99999999)));
            spdNFCeDataSet.SetCampo("natOp_B04=VENDA DE MERCADORIA ADQ. DE TERCEIRO");
            //indPag_B05 removido do esquema//
            spdNFCeDataSet.SetCampo("mod_B06=65");
            spdNFCeDataSet.SetCampo("serie_B07=" + Convert.ToString(Rand.Next(1, 999)));

            spdNFCeDataSet.SetCampo("nNF_B08=" + Convert.ToString(Rand.Next(1, 999999999)));
            spdNFCeDataSet.SetCampo("dhEmi_B09=" + String.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now) + "-03:00");
            spdNFCeDataSet.SetCampo("tpNF_B11=1");
            spdNFCeDataSet.SetCampo("idDest_B11a=1");
            spdNFCeDataSet.SetCampo("cMunFG_B12=2202307");

            spdNFCeDataSet.SetCampo("tpImp_B21=4");

            spdNFCeDataSet.SetCampo("tpEmis_B22=1");
            spdNFCeDataSet.SetCampo("cDV_B23=");
            spdNFCeDataSet.SetCampo("tpAmb_B24=2");
            spdNFCeDataSet.SetCampo("finNFe_B25=1");
            spdNFCeDataSet.SetCampo("indFinal_B25a=1");
            spdNFCeDataSet.SetCampo("indPres_B25b=1");
            spdNFCeDataSet.SetCampo("procEmi_B26=0");
            spdNFCeDataSet.SetCampo("verProc_B27=5");
        }        

        private void DadosPagamento400()
        {

            spdNFCeDataSet.IncluirParte("YA");
            spdNFCeDataSet.SetCampo("tPag_YA02=01");
            spdNFCeDataSet.SetCampo("vPag_YA03=0.60");
            spdNFCeDataSet.SetCampo("vTroco_YA09=0.10"); //Campo novo. Só deve ser informado no dataset, quando o valor dele for maior do que 0.00.
            spdNFCeDataSet.SalvarParte("YA");

            spdNFCeDataSet.IncluirParte("YA");
            spdNFCeDataSet.SetCampo("tPag_YA02=05");
            spdNFCeDataSet.SetCampo("vPag_YA03=0.50");
            spdNFCeDataSet.SalvarParte("YA");
        }

        private void gerarXml(string codICMS)
        {
            spdNFCe.VersaoManual = VersaoManualNFCe.vm60;
            edtNumRecibo.Text = "";
            edtNumProtocolo.Text = "";

            spdNFCeDataSet.VersaoEsquema = "pl_009";
            spdNFCeDataSet.DicionarioXML = spdNFCe.DiretorioTemplates + "\\Conversor\\NFCeDataSets.xml";

            spdNFCeDataSet.Incluir();

            DadosDoNFe400();
            DadosDoEmitente();
            //DadosDoDestinatario();
            DadosDoItem(codICMS); //não houveram mudanças quanto ao esquema dos itens, apenas uma nova validação nas tags cEAN e cEANTrib
            DadosTotalizadores400();
            DadosTransporte();
            DadosAdicionais();
            DadosPagamento400();

            spdNFCeDataSet.Salvar();

            mmXmlEnvio.Text = spdNFCeDataSet.LoteNFCe;
            edtIdNFe.Text = spdNFCeDataSet.GetCampo("Id_A03").ToString().Remove(0, 3);
        }
    }
}
