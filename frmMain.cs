using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json_test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] lines1 = System.IO.File.ReadAllLines(@"C:\Users\adenault.Houston1\Downloads\Anime.json");
            string lines = String.Join("",lines1);
            var result = JsonConvert.DeserializeObject<List<JsonResult>>(lines);
         

            List<List<string>> json = new List< List<string> >();
          
            for (int x = 0; x < result.Count(); x++) {
             
                if (Convert.ToString(result[x].type).ToLower() == "manga")
                 {
                    collectionItem items = new collectionItem(result[x].id,
                                result[x].name,
                                result[x].type,
                                result[x].finished,
                                 result[x].ISBN);



                    OLVSceneList.AddObject(items);

                }
            }

        }

        private void OLVSceneList_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = OLVSceneList.SelectedItems;
            string FirstTitleIDSelected = selectedItems[selectedItems.Count - 1].Text;

        }

    }
    public class JsonResult
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string finished { get; set; }
        public string ISBN { get; set; }
    }
}


class collectionItem
{

    string id;
    string name;
    string type;
    string finished;
    string isbn;

    public collectionItem(string id, string name, string type, string finished, string isbn)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.finished = finished;
        this.isbn = isbn;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    public string Finished
    {
        get { return finished; }
        set { finished = value; }
    }
    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }
}
