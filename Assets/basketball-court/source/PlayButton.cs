using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public Canvas menuCanvas; 

    void Start()
    {
        playButton.onClick.AddListener(OnPlayPressed);
    }

    void OnPlayPressed()
    {
        menuCanvas.gameObject.SetActive(false);
    }
}