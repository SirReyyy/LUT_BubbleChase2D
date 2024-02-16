using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEditor.PackageManager;
using System;
using static UDPReceive;
using Unity.VisualScripting;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.Windows;

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient udpClient;
    public int port = 2024;
    public bool startReceiving = true;
    public bool printToConsole = false;

    // received data
    public string receivedData = null;
    [HideInInspector]
    public string type_1;
    [HideInInspector]
    public string data_lmlist_1;
    [HideInInspector]
    public string center_1;
    [HideInInspector]
    public string type_2;
    [HideInInspector]
    public string data_lmlist_2;
    [HideInInspector]
    public string center_2;

    void Start() {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    } //-- start end

    private void ReceiveData() {
        udpClient = new UdpClient(port);
        while (startReceiving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = udpClient.Receive(ref anyIP);
                receivedData = Encoding.UTF8.GetString(dataByte);

                if (receivedData.Length != 0)
                    HandData(receivedData);

                if (printToConsole) { print(receivedData); }

            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    } //-- ReceiveData end

    private void HandData(string data) {
        string pattern = "\"([^\"]*)\": \"?([^\"]*)\"?(,|})";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(data);
        Dictionary<string, string> handDataPairs = new Dictionary<string, string>();

        if (matches.Count == 3) {
            foreach (Match match in matches) {
                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;
                handDataPairs[key] = value;
            }

            type_1 = handDataPairs["A"];
            data_lmlist_1 = handDataPairs["B"];
            center_1 = handDataPairs["C"];

        } else if (matches.Count == 6) {
            foreach (Match match in matches) {
                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;
                handDataPairs[key] = value;
            }

            type_1 = handDataPairs["A"];
            data_lmlist_1 = handDataPairs["B"];
            center_1 = handDataPairs["C"];
            type_2 = handDataPairs["D"];
            data_lmlist_2 = handDataPairs["E"];
            center_2 = handDataPairs["F"];
        }
    }
} //-- class end


/*
Project: 
Made by: 
*/

