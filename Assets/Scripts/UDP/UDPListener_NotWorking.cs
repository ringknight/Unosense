using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPListener_NotWorking : MonoBehaviour
{
    [SerializeField] string IPAddressEndpoint = "127.0.0.1";
    [SerializeField] int port = 5000;
    private const int listenPort = 11000;
    private UdpClient client;
    private IPEndPoint endPoint;
    private static void StartListener()
    {
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

        Debug.LogWarning("Initialized client");
        try
        {
            float attempts = 0;
            //while (true)
            while (attempts++ < 5)
            {
                Debug.LogWarning("Waiting for broadcast");
                byte[] bytes = listener.Receive(ref groupEP);

                Debug.LogWarning($"Received broadcast from {groupEP} :");
                //Debug.LogWarning($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
            }
        }
        catch (SocketException e)
        {
            Debug.LogError(e);
        }
        finally
        {
            listener.Close();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        client = new UdpClient();

        // Set up the remote endpoint to which we'll send data
        //endPoint = new IPEndPoint(IPAddress.Parse(IPAddressEndpoint), port);
        endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

        Debug.Log("Initialized UDP client at " + IPAddressEndpoint + '/' + port);
        // Start listening for incoming data asynchronously
        client.BeginReceive(new AsyncCallback(ReceiveCallback), null);

        Send("Allo les amis");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReceiveCallback(IAsyncResult result)
    {
        Debug.Log("Received!!");
        // Get the received data and remote endpoint
        //IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
        byte[] receivedBytes = client.EndReceive(result, ref endPoint);
        string receivedMessage = Encoding.ASCII.GetString(receivedBytes);

        // Do something with the received message
        Debug.Log("Received: " + receivedMessage);

        // Continue listening for more data
        client.BeginReceive(new AsyncCallback(ReceiveCallback), null);
    }
    private void OnDestroy()
    {
        // Clean up resources when the object is destroyed
        client.Close();
    }

    public void Send(string message)
    {
        // Convert the message to bytes
        byte[] data = Encoding.ASCII.GetBytes(message);

        IPEndPoint sendEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
        // Send the data asynchronously
        client.Send(data, data.Length, sendEndPoint);
    }

}
