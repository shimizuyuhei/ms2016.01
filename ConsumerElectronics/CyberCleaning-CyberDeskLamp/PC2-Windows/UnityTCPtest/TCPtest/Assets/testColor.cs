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

public class testColor : MonoBehaviour
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
        if (Colorflg)
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
            if(Colorflg)
            {
                //Colorflg = false;
            }else
            {
                //Colorflg = true;
            }
            //Thread.Sleep(1000);
        }
    }
}
