using System;
using UnityEngine;
using System.Collections;

/*通信宣言*/
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

/*スレット*/
using System.Threading;

public class testTCP : MonoBehaviour
{

    private bool Colorflg = true;
    public GameObject myCube;

    private Thread TCP_Thread;

    private StreamReader sr;
    private StreamWriter sw;

    // Use this for initialization
    void Start()
    {

        //青色に変更
        this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);

        TCP_Thread = new Thread(threadWork);
        TCP_Thread.Start();

    }

    // Update is called once per frame
    void Update()
    {
        if(Colorflg)
        {
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        }
        else
        {
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        }
    }


    //------------------------------------------------------------
    // job process on thread
    //------------------------------------------------------------
    private void threadWork()
    {
        while (true)
        {
            /*ネットワーク設定用タスク*/
            /*ネットワークの設定*/
            /*自分のIPアドレス,ポート番号*/
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("172.29.9.107"), 8888);
            TcpClient client = new TcpClient();

            /*サーバーに接続できたかの判定*/
            try
            {
                client.Connect(ep);     //接続の開始　Connect(繋ぐ)
                Debug.Log("接続された");

                NetworkStream ns = client.GetStream();
                sr = new StreamReader(ns);  //読み込み
                sw = new StreamWriter(ns, Encoding.UTF8);   //文字コードを指定して送信
                sw.AutoFlush = true;    //一行書き込んだら送信する

                Recive();

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);   //接続できなかった場合の処理
            }
        }
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
            Debug.Log(str);
            Debug.Log(str.Contains("a"));
            Colorflg = str.Contains("a");
        } while (true);
    }

}
