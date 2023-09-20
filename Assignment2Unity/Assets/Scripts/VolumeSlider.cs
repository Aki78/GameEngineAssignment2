using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioController audioController;

    private void Start()
    {
        volumeSlider.value = 0.5f; // Default volume
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float volume)
    {
        print(volume);
        audioController.SetVolume(volume);
    }
}
