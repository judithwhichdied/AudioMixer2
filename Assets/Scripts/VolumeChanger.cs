using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private VolumeSwitcher _volumeMute;
    [SerializeField] private string _volumeName;

    private Slider _slider;

    public event Action<string> VolumeChanged;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        VolumeChanged?.Invoke(_volumeName);
    }

    private void OnEnable()
    {
        VolumeChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        VolumeChanged -= ChangeVolume;
    }

    public void ChangeVolume(string volumeName)
    {
        if (_volumeMute.Enabled == false)
        {
            float volumeLevel = _slider.value;

            _mixer.audioMixer.SetFloat(volumeName, Mathf.Log10(volumeLevel) * 20);
        }
    }
}