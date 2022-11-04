using ObserverWinFormTest.Components;
using ObserverWinFormTest.Entity;
using ObserverWinFormTest.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ObserverWinFormTest
{
    public partial class Wrapper : Form
    {
        public List<FlowType> FlowTypes;
        public List<AssetType> AssetTypes;

        public readonly ListBoard CurrentListBoard;
        private readonly MessagesHandler _provider = new MessagesHandler();

        public Wrapper()
        {
            GetSettings();

            InitializeComponent();
            CurrentListBoard = new ListBoard(_provider);

            Controls.Add(CurrentListBoard);
            CurrentListBoard.Dock = DockStyle.Fill;
            groupBox1.SendToBack();
        }

        public void Process(Message message)
        {
            _provider.MessageAdd(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = new Message()
            {
                Content = textBox1.Text,
                Asset = new Asset { AssetType = new AssetType { Type = comboBox1.SelectedItem.ToString() } }
            };
            Process(message);
        }

        private void Wrapper_Load(object sender, EventArgs e)
        {
            foreach (var item in AssetTypes)
            {
                comboBox1.Items.Add(item.Type);
            }
            //var testTypes = new List<string>((IEnumerable<string>)Properties.Settings.Default.TestTypes);
            //var testTypes = Properties.Settings.Default.TestTypes.Cast<string>().ToList();
            //foreach (var item in testTypes)
            //{
            //    comboBox1.Items.Add(item);
            //}
            comboBox1.SelectedIndex = 0;
        }

        private void GetSettings()
        {
            var operations = new Operations();
            if (Properties.Settings.Default.AssetTypes.Length == 0 || true)
            {
                var assetTypeList = new List<AssetType>
                 {
                    new AssetType() { Type = "Bakım Grubu" },
                    new AssetType() { Type = "İş Güvenliği Elemanı" },
                    new AssetType() { Type = "İşçi" },
                    new AssetType() { Type = "Kalite Kontrol Elemanı" },
                    new AssetType() { Type = "Mühendis" },
                    new AssetType() { Type = "Sağlık Personeli" },
                    new AssetType() { Type = "Ustabaşı" },
                    new AssetType() { Type = "Yangın Savunma Elemanı" },
                    new AssetType() { Type = "Yönetici" },
                    new AssetType() { Type = "Ziyaretçi" }
                };
                operations.Save(assetTypeList, value => Properties.Settings.Default.AssetTypes = value);
            }
            var list = operations.Load<AssetType>(Properties.Settings.Default.AssetTypes);
            AssetTypes = list.OrderBy(t => t.Type).ToList();
        }
    }
}
