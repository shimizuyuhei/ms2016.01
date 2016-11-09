using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*通信宣言*/
using System.Net;
using System.Net.Sockets;
using System.IO;

/*スレット*/
using System.Threading.Tasks;

namespace TCPserver
{
	public partial class Form1 : Form
	{
		//別スレットを使うときデリゲートを使う
		private delegate void DelegateSetText(string str);

		private StreamReader sr;
		private StreamWriter sw;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			/*
			//ネットワークの設定
															//自分のIPアドレス,ポート番号
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.182.133"),8888);
			TcpListener listener = new TcpListener(ep);
			listener.Start();
			TcpClient client = listener.AcceptTcpClient();
			*/

			/*タスクの実行*/
			Task.Factory.StartNew(() => WaitConnect());

		}

		/*ネットワーク設定用タスク*/
		private void WaitConnect()
		{
			/*ネットワークの設定*/
			/*自分のIPアドレス,ポート番号*/
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("172.29.9.107"), 8888);
			TcpListener listener = new TcpListener(ep);
			listener.Start();
			TcpClient client = listener.AcceptTcpClient();

			NetworkStream ns = client.GetStream();
			sr = new StreamReader(ns);	//読み込み
			sw = new StreamWriter(ns, Encoding.UTF8);	//文字コードを指定して送信
			sw.AutoFlush = true;	//一行書き込んだら送信する

			/*マルチスレットを立ち上げる*/
			Task.Factory.StartNew(() => Recive());
		}

		private void Recive()
		{
			string str = string.Empty;
			do
			{
				str = sr.ReadLine();
				if (str == null)
				{
					break;
				}
				//txtDisp.Text = str;
				Invoke(new DelegateSetText(SetText), str);	//テキストに書き込むスレットを呼び出す
			} while (true);
		}

		private void SetText(string str)
		{
			txtDisp.Text += str + "\r\n";
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (sw != null)
			{
				if (txtSend.Text != null)
				{
					sw.WriteLine(txtSend.Text);
				}
			}
			txtSend.Text = null;
		}

		
	}
}
