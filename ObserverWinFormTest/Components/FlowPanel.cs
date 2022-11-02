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
        private readonly List<string> _messages;
        public string Type;
        SolidBrush brush = new SolidBrush(Color.White);
        Font titleFont;
        public FlowPanel(MessagesHandler provider, string type)
        {
            Type = type;

            _messages = new List<string>();
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
            if (value.Type != Type) return;

            _messages.Add(value.Content);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = new Rectangle(5, 25, Width - 10, Height - 10);
            e.Graphics.Clear(this.BackColor);

            e.Graphics.DrawString(Type, titleFont, brush, 5, 5);
            e.Graphics.DrawString(string.Join(",", _messages), this.Font, brush, rec);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

    }
}
