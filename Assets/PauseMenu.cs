using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    private bool _enabled = false;

    private void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }

    public void ToggleMusic()
    {
        if (_enabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, 0);
            _enabled = false;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, -80);
            _enabled = true;
        }
    }
}
