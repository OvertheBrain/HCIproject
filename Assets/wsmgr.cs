using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.WebSocket;
using System;
using BestHTTP.Examples;
using UnityEngine.UI;
using System.Text;
using Newtonsoft.Json;
public class wsmgr : MonoBehaviour {
 
    //public string url = "ws://localhost:8080/web1/websocket";
    public string url = "ws://localhost:9000";
    public RobotController rb;

    

 
    private WebSocket webSocket;
 
    private void Start()
    {
        init();
    }
 
    private void init()
    {
        rb=GetComponent<RobotController>();
        webSocket = new WebSocket(new Uri(url));
        webSocket.OnOpen += OnOpen;
        webSocket.OnMessage += OnMessageReceived;
        webSocket.OnError += OnError;
        webSocket.OnClosed += OnClosed;
        Connect();
    }
 
    private void antiInit()
    {
        webSocket.OnOpen = null;
        webSocket.OnMessage = null;
        webSocket.OnError = null;
        webSocket.OnClosed = null;
        webSocket = null;
    }

    public void Connect()
    {
        webSocket.Open();
        
    }
 
    private byte[] getBytes(string message)
    {
 
        byte[] buffer = Encoding.Default.GetBytes(message);
        return buffer;
    }
 
    public void Send(string str)
    {
        webSocket.Send(str);
    }
 
    public void Close()
    {
        webSocket.Close();
    }

    #region WebSocket Event Handlers

    /// <summary>
    /// Called when the web socket is open, and we are ready to send and receive data
    /// </summary>
    void OnOpen(WebSocket ws)
    {
        Send("unity_connect");
        Debug.Log("connected");
    }

    /// <summary>
    /// Called when we received a text message from the server
    /// </summary>
    void OnMessageReceived(WebSocket ws, string message)
    {
        //Debug.Log(message);
        PoseJson pose = JsonConvert.DeserializeObject<PoseJson>(message);

        // if(pose!=null)
        rb.UpdatePose(pose);
        //Debug.Log(pose.RightUpperArm.x);
    }

    /// <summary>
    /// Called when the web socket closed
    /// </summary>
    void OnClosed(WebSocket ws, UInt16 code, string message)
    {
        Debug.Log(message);
        antiInit();
        init();
    }

    private void OnDestroy()
    {
        if (webSocket != null && webSocket.IsOpen)
        {
            webSocket.Close();
            antiInit();
        }
    }

    /// <summary>
    /// Called when an error occured on client side
    /// </summary>
    void OnError(WebSocket ws, String ex)
    {
        string errorMsg = ex;
#if !UNITY_WEBGL || UNITY_EDITOR
        if (ws.InternalRequest.Response != null)
            errorMsg = string.Format("Status Code from Server: {0} and Message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);
#endif
        Debug.Log(errorMsg);

        antiInit();
        init();
    }

    #endregion


}