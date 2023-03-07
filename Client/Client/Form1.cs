using CoreLib;
using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
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
            // Створюю Http канал, та реєструю його в канальному сервісі, для того щоб його використовувати
            HttpChannel ch = new HttpChannel();
            ChannelServices.RegisterChannel(ch, false);
            // Створюю проксі об'єкт віддаленого сервісу
            _remote = (TextSorter)Activator.GetObject(
                        typeof(TextSorter),
                        "http://localhost:5000/TextSorter.soap");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = Input.Text;

            // Викликаю віддалену функцію сортування слів
            var res = _remote.SortWords(str);

            Result.Text = res;
        }
    }
}
