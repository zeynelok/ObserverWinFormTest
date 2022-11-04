using ObserverWinFormTest.Entity;

namespace ObserverWinFormTest
{
    public class Message
    {
        public string Content { get; set; }
        public Asset Asset { get; set; }

        public override string ToString()
        {
            return $"{Content} - {Asset.AssetType.Type}";
        }
    }
}
