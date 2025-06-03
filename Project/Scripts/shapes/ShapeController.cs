
using UnityEngine;

public class ShapeController : Shape
{
    private Vector3 initialPosition;
    public TypeOfShape shape;
    public ParticleSystem CorrectParticle;
    public ParticleSystem WrongParticle;

    void Start()
    {
        if (shape == TypeOfShape.Circle)
        {
            Debug.Log("Started for circle");
        }
        initialPosition = transform.position;
    }

    public void respawn()
    {
        transform.position = initialPosition;
        gameObject.SetActive(false);
    }

    public void playParticles(bool isCorrect)
    {
        if (isCorrect) CorrectParticle.Play();
        else WrongParticle.Play();
    }
}
