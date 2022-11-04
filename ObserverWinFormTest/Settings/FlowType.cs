using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverWinFormTest.Settings
{
    [Serializable]
    public class FlowType
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public List<AssetType> AssetTypes { get; set; }
    }
}
