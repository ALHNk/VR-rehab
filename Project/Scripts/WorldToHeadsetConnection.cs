using UnityEngine;

public class WorldToHeadsetConnection : MonoBehaviour
{
    public Transform Headset;

    void Start()
    {
        transform.position = Headset.position;
    }
}
