  using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class getSpeed : MonoBehaviour
{
    public float receivedSpeed;
    private UdpClient udpClient;
    private Thread receiveThread;

    void Start()
    {
        udpClient = new UdpClient(9050); 
        receiveThread = new Thread(ReceiveData);
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void ReceiveData()
    {
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
        while (true)
        {
            byte[] data = udpClient.Receive(ref remoteEP);
            string msg = Encoding.ASCII.GetString(data);
            if (float.TryParse(msg, out float speed))
            {
                receivedSpeed = speed;
            }
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * receivedSpeed * Time.deltaTime);
    }

    void OnApplicationQuit()
    {
        receiveThread.Abort();
        udpClient.Close();
    }
}
