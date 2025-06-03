using UnityEngine;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;

public class AndroidTreadmillSimulator : MonoBehaviour
{
    public float maxZ, minZ;
    public float speed;
    private Vector3 lastPosition;
    private float lastTime;
    private Vector3 touchStart;
    public InputField IpText;

    UdpClient udpClient;

    void Start()
    {
        lastPosition = transform.position;
        lastTime = Time.time;
        udpClient = new UdpClient();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(t.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, hit.point.z);
                float deltaTime = Time.time - lastTime;
                speed = Vector3.Distance(lastPosition, newPos) / deltaTime;

                transform.position = newPos;
                lastPosition = newPos;
                lastTime = Time.time;

                if (transform.localPosition.z > maxZ)
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minZ);
                else if (transform.localPosition.z < minZ)
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, maxZ);

                SendSpeed(speed);
            }
        }
        else
        {
            speed = 0;
            SendSpeed(speed);
        }
    }

    void SendSpeed(float s)
    {
        string msg = s.ToString("F2");
        byte[] data = Encoding.ASCII.GetBytes(msg);
        udpClient.Send(data, data.Length, IpText.text, 9050); 
    }

    void OnApplicationQuit()
    {
        udpClient.Close();
    }
}
