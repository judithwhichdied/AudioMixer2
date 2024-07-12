using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSwitcher : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Button _button;

    private float _minVolumeLevel = -80f;
    private float _maxVolumeLevel = 0f;

    public bool Enabled { get; private set; } = false;

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleMusic);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMusic);
    }

    public void ToggleMusic()
    {
        if (Enabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _maxVolumeLevel);
            Enabled = false;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _minVolumeLevel);
            Enabled = true;
        }
    }
}
