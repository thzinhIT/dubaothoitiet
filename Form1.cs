using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;

namespace dubaothoitiet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        // http://home.openweathermap.org/users/sign_in -- link đăng ký lấy API
        private const string API_KEY = "c7055ce01673bc05bf8af1cb09e60bd2";

       
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;

        
        private string[] QueryCodes = { "q", "zip", "id", };

        
        private void Form1_Load(object sender, EventArgs e)
        {
            cboQuery.Items.Add("City");
            cboQuery.Items.Add("ZIP");
            cboQuery.Items.Add("ID");

            cboQuery.SelectedIndex = 0;
        }

        
        private void btnForecast_Click(object sender, EventArgs e)
        {
            
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);
            url = url.Replace("@QUERY@", QueryCodes[cboQuery.SelectedIndex]);

           
            using (WebClient client = new WebClient())
            {
                
                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
        }

      
        private void DisplayForecast(string xml)
        {
           
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtCity.Text = loc_node.SelectSingleNode("name").InnerText;
            txtCountry.Text = loc_node.SelectSingleNode("country").InnerText;
            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txtLat.Text = geo_node.Attributes["latitude"].Value;
            txtLong.Text = geo_node.Attributes["longitude"].Value;
            txtId.Text = geo_node.Attributes["geobaseid"].Value;

            lvwForecast.Items.Clear();
            char degrees = (char)176;
            
            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
               
                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);

              
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;

                ListViewItem item = lvwForecast.Items.Add(time.DayOfWeek.ToString());
                item.SubItems.Add(time.ToShortTimeString());
                item.SubItems.Add(temp + degrees);
            }
        }

      
        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error\n" + ex.Message);
            }
        }
    }
}
