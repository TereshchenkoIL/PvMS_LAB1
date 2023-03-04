using CoreLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private TextSorter _remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpChannel ch = new HttpChannel();
            ChannelServices.RegisterChannel(ch, false);

            _remote = (TextSorter)Activator.GetObject(
                        typeof(TextSorter),
                        "http://localhost:5000/TextSorter.soap");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = Input.Text;

            var res = _remote.SortWords(str);

            Result.Text = res;
        }
    }
}
