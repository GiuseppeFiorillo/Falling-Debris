using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _livesSprites;

    [SerializeField]
    private Image _livesImage;

    public void updateLives(int currentLives)
    {
        _livesImage.sprite = _livesSprites[currentLives];
    }
}
