using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace MigrationConvertor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileLegacy;
        
        DataFlowObject _dataFlowObject = new DataFlowObject();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                FileNameTextBox.Text = fileDialog.FileName;
                fileLegacy = File.ReadAllText(fileDialog.FileName);
                      
                textBoxOutput.Text = _dataFlowObject.buildDataFlow(fileLegacy);
            }
        }

        private void textBoxOutput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CardsLang
{
    class FileImplementaion
    {
        private AddLists _cardsList;
        public FileImplementaion()
        {
            _cardsList = new AddLists();
        }

        private string GetOrCreateFile()
        {
            var filePath = GetFilePath();
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, "");
            }
            return File.ReadAllText(filePath);

        }
        public Dictionary<string, List<Card>> getDictFromFile()
        {
            Dictionary<string, List<Card>> dict = new Dictionary<string, List<Card>>();
            string tempList;
            string fileData = GetOrCreateFile();
            if (GetOrCreateFile() != "")
            {
                Dictionary<string, object> dictTemp = JsonConvert.DeserializeObject<Dictionary<string, object>>(GetOrCreateFile());
                foreach (var obj in dictTemp)
                {
                    dict.Add(obj.Key, new List<Card>());
                    tempList = obj.Value.ToString();
                    List<object> jsonObject = JsonConvert.DeserializeObject<List<object>>(tempList);
                    foreach (var row in jsonObject)
                    {
                        var _cards = JsonConvert.DeserializeObject<dynamic>(row.ToString());
                        dict[obj.Key].Add(new Card(_cards._front.Value, _cards._back.Value));
                    }

                }
            }
            return dict;

        }
        public bool saveDictToFile(Dictionary<string, List<Card>> dict)
        {
            string fileData;
            var filePath = GetFilePath();
            if (filePath != null)
            {
                fileData = convertToJson(dict);
                File.WriteAllText(filePath, fileData);
                return true;
            }

            return false;
        }
        private string convertToJson(Dictionary<string, List<Card>> dict)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize((object)dict);
        }
        private static string GetFilePath()
        {
            var cardsFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "CardsList",
                "CardsList.txt");
            return cardsFilePath;
        }

    }
}
*/