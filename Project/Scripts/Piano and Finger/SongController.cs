using Unity.XR.CoreUtils;
using UnityEngine;

public class SongController : MonoBehaviour
{
    [SerializeField] PublicEnvironemnt publicEnvironemnt;
    [SerializeField] UIManagement ui;
    public GameObject[] songKeysOrder;
    public Material NextKeyMaterial;
    public Material originalWhiteMaterial;
    public Material originalBlackMaterial;

    private bool isPressedForNow = false;
    private int index = 0;
    private Material previousMaterial;
    void Start()
    {
        previousMaterial = songKeysOrder[0].GetComponent<Renderer>().material;
        songKeysOrder[0].GetComponent<Renderer>().material = NextKeyMaterial;
        songKeysOrder[0].GetComponent<Key>().isNextToPress = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (index < songKeysOrder.Length - 1)
        {
            if (songKeysOrder[index].GetComponent<Key>().isPressed == true && isPressedForNow == false)
            {
                songKeysOrder[index].GetComponent<Key>().isNextToPress = false;
                songKeysOrder[index].GetComponent<Renderer>().material = previousMaterial;
                previousMaterial = songKeysOrder[index + 1].GetComponent<Renderer>().material;
                songKeysOrder[index + 1].GetComponent<Renderer>().material = NextKeyMaterial;
                songKeysOrder[index + 1].GetComponent<Key>().isNextToPress = true;
                isPressedForNow = true;
                index++;
            }
            else
            {
                isPressedForNow = false;
            }
        }

        else if (index == songKeysOrder.Length - 1)
        {

            if (songKeysOrder[index].GetComponent<Key>().isPressed == true && isPressedForNow == false)
            {
                publicEnvironemnt.isWon = true;
                ui.levelCompleted();
                isPressedForNow = true;
            }
            else
            {
                isPressedForNow = false;
            }
        }
        
    }
}
