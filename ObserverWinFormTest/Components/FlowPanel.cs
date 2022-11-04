using ObserverWinFormTest.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ObserverWinFormTest.Components
{
    public partial class FlowPanel : Control, IObserver<Message>
    {
        private IDisposable _cancellation;

        private readonly List<Message> _messages;
        private readonly string _name;
        public List<string> Types;
        SolidBrush brush = new SolidBrush(Color.White);
        Font titleFont;

        public FlowPanel(MessagesHandler provider, string name, IEnumerable<string> types)
        {
            _name = name;
            Types = types.ToList();

            _messages = new List<Message>();
            _cancellation = provider.Subscribe(this);

            titleFont = new Font(this.Font, FontStyle.Bold);
        }

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Message value)
        {
            if (!Types.Any(t => t == value.Asset.AssetType.Type)) return;

            _messages.Add(value);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = new Rectangle(5, 25, Width - 10, Height - 10);
            e.Graphics.Clear(this.BackColor);

            e.Graphics.DrawString($"{_name} : {string.Join(" / ", Types)}", titleFont, brush, 5, 5);
            e.Graphics.DrawString(string.Join(", ", _messages.Select(m => m.ToString())), this.Font, brush, rec);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
