using ObserverWinFormTest.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverWinFormTest
{
    public partial class Wrapper : Form
    {
        public readonly ListBoard CurrentListBoard;
        private readonly MessagesHandler _provider = new MessagesHandler();
        public Wrapper()
        {
            InitializeComponent();
            CurrentListBoard = new ListBoard(_provider);

            Controls.Add(CurrentListBoard);
            CurrentListBoard.Dock = DockStyle.Fill;
            groupBox1.SendToBack();
            comboBox1.SelectedIndex = 0;
        }



        public void Process(Message message)
        {
            _provider.MessageAdd(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = new Message() {
                Content = textBox1.Text,
                Type = comboBox1.SelectedItem.ToString()
            };
            Process(message);
        }

    }
}
