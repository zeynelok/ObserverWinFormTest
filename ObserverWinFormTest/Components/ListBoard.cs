using ObserverWinFormTest.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ObserverWinFormTest.Components
{
    public partial class ListBoard : Control
    {
        public List<FlowType> FlowTypes;

        public readonly List<FlowPanel> _flowPanelList;

        private readonly int _padding;

        public ListBoard(MessagesHandler provider)
        {
            _flowPanelList = new List<FlowPanel>();
            _padding = 20;

            GetSettings();
            //GetSettings2();

            foreach (var flow in FlowTypes)
            {
                var flowPanel = new FlowPanel(provider, flow.Name, flow.AssetTypes.Select(a => a.Type));
                flowPanel.BackColor = Color.FromName(flow.Color);
                _flowPanelList.Add(flowPanel);
            }

            Controls.AddRange(_flowPanelList.ToArray());
        }

        public void Initialize()
        {
            var flowPanelHeight = (Height - (_flowPanelList.Count + 1) * _padding) / _flowPanelList.Count;
            var startPanelLocation = _padding;

            foreach (var flowPanel in _flowPanelList)
            {
                flowPanel.Width = Width - 2 * _padding;
                flowPanel.Height = flowPanelHeight;
                flowPanel.Location = new Point(_padding, startPanelLocation);

                startPanelLocation += flowPanelHeight + _padding;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Initialize();
        }

        private void GetSettings()
        {
            var operations = new Operations();
            if (Properties.Settings.Default.FlowTypes.Length == 0 || true)
            {
                var flowTypeList = new List<FlowType>
                {
                    new FlowType { Name = "Panel1", Color = "Red", AssetTypes = new List<AssetType> {
                                                                                                        new AssetType { Type = "Mühendis" },
                                                                                                        new AssetType { Type = "Sağlık Personeli" },
                                                                                                        new AssetType { Type = "Yönetici" }
                                                                                                    } },
                    new FlowType { Name = "Panel2", Color = "Blue", AssetTypes = new List<AssetType> {
                                                                                                        new AssetType { Type = "Ustabaşı" },
                                                                                                        new AssetType { Type = "İşçi" }
                                                                                                      } },
                    new FlowType { Name = "Panel2.1", Color = "Black", AssetTypes = new List<AssetType> {
                                                                                                            new AssetType { Type = "Bakım Grubu" },
                                                                                                            new AssetType { Type = "Yangın Savunma Elemanı" },
                                                                                                            new AssetType { Type = "Kalite Kontrol Elemanı" },
                                                                                                            new AssetType { Type = "İş Güvenliği Elemanı" }
                                                                                                          } },
                    new FlowType { Name = "Panel3", Color = "Green", AssetTypes = new List<AssetType> {
                                                                                                        new AssetType { Type = "Ziyaretçi" }
                                                                                                       } }
                };
                operations.Save(flowTypeList, value => Properties.Settings.Default.FlowTypes = value);
            }
            FlowTypes = operations.Load<FlowType>(Properties.Settings.Default.FlowTypes);
        }

        private void GetSettings2()
        {
            var operations = new Operations();
            if (Properties.Settings.Default.FlowTypes.Length == 0 || true)
            {
                var flowTypeList = new List<FlowType>
                {
                    new FlowType { Name = "Panel1", Color = "Red", AssetTypes = new List<AssetType> {
                                                                                                        new AssetType { Type = "Mühendis" },
                                                                                                        new AssetType { Type = "Sağlık Personeli" },
                                                                                                        new AssetType { Type = "Yönetici" },
                                                                                                        new AssetType { Type = "Ustabaşı" },
                                                                                                        new AssetType { Type = "İşçi" },
                                                                                                            new AssetType { Type = "Bakım Grubu" },
                                                                                                            new AssetType { Type = "Yangın Savunma Elemanı" },
                                                                                                            new AssetType { Type = "Kalite Kontrol Elemanı" },
                                                                                                            new AssetType { Type = "İş Güvenliği Elemanı" },
                                                                                                         new AssetType { Type = "Ziyaretçi" }
                                                                                                   } }
                };
                operations.Save(flowTypeList, value => Properties.Settings.Default.FlowTypes = value);
            }
            FlowTypes = operations.Load<FlowType>(Properties.Settings.Default.FlowTypes);
        }
    }
}
