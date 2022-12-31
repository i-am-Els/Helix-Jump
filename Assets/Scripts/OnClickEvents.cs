using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            soundsText.text = "X";
        }
        else
        {
            soundsText.text = "";
        }
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "X";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
