using UnityEngine;
using System.Collections;

public class MediumRotater : MonoBehaviour
{
    
    public float rotationSpeed = 2.5f;
    //this is for Medium level
    private bool isRotating = false;

    //The next 2 are for hard level, 4 objects.
    public GameObject[] mainObjects;
    public GameObject[] secondaryObjects;
    public LevelDifficultyManager levelDifficultyManager;

    public void doForDifferentLevels()
    {
        if (levelDifficultyManager.LevelDifficulty == 0)
        {
            return;
        }
        else if (levelDifficultyManager.LevelDifficulty == 1)
        {
            RotateBy90Degrees();
        }
        else
        {
            changeRandomlyPosition();
        }
    }

    private void RotateBy90Degrees()
    {
        if (!isRotating)
        {
            StartCoroutine(SmoothRotateBy90Degrees());
        }
    }

    private IEnumerator SmoothRotateBy90Degrees()

    {
        isRotating = true;

        Quaternion initialRotation = transform.rotation;

        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 90, 0);

        float timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, timeElapsed);
            timeElapsed += Time.deltaTime * rotationSpeed;

            yield return null;
        }

        transform.rotation = targetRotation;

        isRotating = false;
    }

    private void changeRandomlyPosition()
    {
        int random = Random.Range(0, mainObjects.Length);
        (mainObjects[0].transform.position, secondaryObjects[random].transform.position) = (secondaryObjects[random].transform.position, mainObjects[0].transform.position);
        (mainObjects[0].transform.rotation, secondaryObjects[random].transform.rotation) = (secondaryObjects[random].transform.rotation, mainObjects[0].transform.rotation);
        (mainObjects[1].transform.position, secondaryObjects[1-random].transform.position) = (secondaryObjects[1-random].transform.position, mainObjects[1].transform.position);
        (mainObjects[1].transform.rotation, secondaryObjects[1-random].transform.rotation) = (secondaryObjects[1-random].transform.rotation, mainObjects[1].transform.rotation);
        

    }
}
