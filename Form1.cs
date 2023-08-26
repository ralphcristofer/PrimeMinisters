using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Configuration;

namespace PrimeMinisters
{
    public partial class frmPrimeMinisters : Form
    {
        // Create a Dictionary object with type <string, PrimeMinister>
        private Dictionary<string, PrimeMinister> primeMinisters = 
            new Dictionary<string, PrimeMinister>();

        public frmPrimeMinisters()
        {
            InitializeComponent();
        }

        private void frmPrimeMinisters_Load(object sender, EventArgs e)
        {
            // File path of the JSON
            string jsonFile = @"..\..\json\PrimeMinisters.json";

            // Creating TextReader variable to read the JSON file
            TextReader streamReader = new StreamReader(jsonFile);

            // Deserialize the JSON file to primeMinisters object
            primeMinisters = JsonSerializer.Deserialize
                <Dictionary<string, PrimeMinister>>(streamReader.ReadToEnd());

            // List primeMinisters in the ListBox
            lstPrimeMinisters.DataSource = primeMinisters.Keys.ToList<string>();
        }

        private void lstPrimeMinisters_SelectedValueChanged(object sender, EventArgs e)
        {
            // Get the selected value in the ListBox
            string selected = lstPrimeMinisters.SelectedValue.ToString();

            // Fill the informations
            lblName.Text = primeMinisters[selected].FirstName + " " +
                primeMinisters[selected].LastName;

            lblTerm.Text = primeMinisters[selected].Term;

            lblParty.Text = primeMinisters[selected].Party;

            string picture = @"..\..\images\";

            picPhoto.ImageLocation = picture + primeMinisters[selected].LastName + ".jpg";
            
        }
    }
}
