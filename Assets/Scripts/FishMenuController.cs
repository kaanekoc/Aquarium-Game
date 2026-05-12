using UnityEngine;

public class FishMenuController : MonoBehaviour
{
    public GameObject fishMenuPanel;

    public void ToggleFishMenu()
    {
        fishMenuPanel.SetActive(!fishMenuPanel.activeSelf);
    }
}
