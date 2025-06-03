using UnityEngine;

public class ui : MonoBehaviour
{
    private bool isPanelOpen;
    [SerializeField] GameObject panel;
    void Start()
    {
        panel.SetActive(false);
        isPanelOpen = false;
    }
    public void PanelOpenClose()
    {
        if (isPanelOpen == true)
        {
            panel.SetActive(false);
            isPanelOpen = false;
        }
        else
        {
            panel.SetActive(true);
            isPanelOpen = true;
        }
    }
}
