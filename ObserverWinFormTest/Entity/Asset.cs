using ObserverWinFormTest.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverWinFormTest.Entity
{
    public class Asset
    {
        public string Name { get; set; }
        public int Tag { get; set; }
        public AssetType AssetType { get; set; }
    }
}
