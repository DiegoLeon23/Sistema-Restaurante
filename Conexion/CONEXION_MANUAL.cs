using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Sistema_Restaurante_Polleria.Conexion
{
    public partial class CONEXION_MANUAL : Form
    {
        private Librerias.AES aes = new Librerias.AES();
        public CONEXION_MANUAL()
        {
            InitializeComponent();
        }

        public void SaveToXML(Object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
        string dcbnString;
        public void ReadFromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dcbnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dcbnString, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void CONEXION_MANUAL_Load(object sender, EventArgs e)
        {
            ReadFromXML();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveToXML(aes.Encrypt(txtCnString.Text, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
        }


    }
}
