using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>("med");
        audioSource.clip = clip;
        audioSource.loop = true; // Loop the music

        // Load volume when the game starts
        audioSource.volume = SaveVolumeSystem.LoadVolume();

        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveVolume();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Method to save volume
    private void SaveVolume()
    {
        SaveVolumeSystem.SaveVolume(audioSource.volume);
    }
}
