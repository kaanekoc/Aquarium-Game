using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    public GameObject volumePanel;  // Paneli gizleyip göstereceðiz
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumePanel.SetActive(false); // Baþta gizli
    }

    public void ToggleVolumePanel()
    {
        volumePanel.SetActive(!volumePanel.activeSelf);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
