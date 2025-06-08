using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ShapeChecker : Shape
{
    public TypeOfShape shape;
    public UIManagement ui;
    public ObjectSpawner spawner;

    [SerializeField] MediumRotater mediumRotater;     //only for medium difficulty level
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shape")
        {
            ShapeController shapeController = other.GetComponent<ShapeController>();
            if (shapeController.shape == shape)
            {
                correct();
                shapeController.playParticles(true);
            }
            else
            {
                incorrect();
                shapeController.playParticles(false);

            }

            shapeController.respawn();
            spawner.spawn();
            mediumRotater.doForDifferentLevels();
        }
    }

    public void correct()
    {
        ui.incScore();

    }
    public void incorrect()
    {
        ui.decScore();
    }
}
