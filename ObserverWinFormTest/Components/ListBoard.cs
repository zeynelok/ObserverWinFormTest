using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverWinFormTest.Components
{
    public partial class ListBoard : Control
    {
        public readonly List<FlowPanel> _flowPanelList;

        private readonly int _padding;

        public ListBoard(MessagesHandler provider)
        {
            _flowPanelList = new List<FlowPanel>();
            _padding = 20;
            

            var flowPanelType1 = new FlowPanel(provider, "Mühendis");
            flowPanelType1.BackColor = Color.Red;
            _flowPanelList.Add(flowPanelType1);

            var flowPanelType2 = new FlowPanel(provider, "İşçi");
            flowPanelType2.BackColor = Color.Blue;
            _flowPanelList.Add(flowPanelType2);

            var flowPanelType3 = new FlowPanel(provider, "Ziyaretçi");
            flowPanelType3.BackColor = Color.Green;
            _flowPanelList.Add(flowPanelType3);

            Controls.AddRange(_flowPanelList.ToArray());
        }

        public void Initialize()
        {
            var flowPanelHeight = (Height - (_flowPanelList.Count+1) * _padding)/_flowPanelList.Count;
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
      
    }
}
