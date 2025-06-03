using UnityEngine;

public class FireSwitcher : MonoBehaviour
{
    private float fireStayTime = 0f;
    public float requiredTime = 3f;
    private bool fireOff = false;
    [SerializeField] UIManagement ui;
    public RandomFireSpawn fireSpawner;

    void OnTriggerStay(Collider other)
    {
        if (fireOff) return;

        if (other.CompareTag("Fire"))
        {
            fireStayTime += Time.deltaTime;

            if (fireStayTime >= requiredTime)
            {
                other.gameObject.SetActive(false);
                ui.incScore();
                fireSpawner.spawn();
                fireOff = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            fireStayTime = 0f;
        }
        fireOff = false;
    }
}
