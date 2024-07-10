using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] AudioMixerGroup _mixer;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeVolume(string volumeName)
    {
        float volumeLevel = _slider.value;

        _mixer.audioMixer.SetFloat(volumeName, Mathf.Log10(volumeLevel) * 20);
    }
}