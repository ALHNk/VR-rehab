using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] shapes;
    private int shapesSize;
    [SerializeField] UIManagement ui;

    

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            shapesSize = shapes.Length;
            foreach (GameObject shape in shapes)
            {
                shape.SetActive(false);
            }
            spawn();
        }

       

    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (OVRInput.GetDown(OVRInput.Button.One))
    //     {
    //         spawn();
    //     }
    // }

    public void spawn()
    { 
        ui.deQuantity();
        int random = Random.Range(0, shapesSize);
        shapes[random].SetActive(true);
    }


}
