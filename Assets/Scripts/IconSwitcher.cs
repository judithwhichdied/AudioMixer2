using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite _iconOn;
    [SerializeField] private Sprite _iconOff;
    [SerializeField] private Button _button;

    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Switch);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Switch);
    }

    public void Switch()
    {
        if (_buttonImage.sprite == _iconOn)
        {
            _buttonImage.sprite = _iconOff;
        }
        else
        {
            _buttonImage.sprite = _iconOn;
        }
    }
}
