using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static bool gameOver;
    public static bool levelComplete;
    public static bool isGameStarted;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;


    public static int currentLevelIndex;
    public Slider gameProgressSlider;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public static int numberOfPassedRings; 
    public static int score = 0;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("currentLevelIndex", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        gameOver = false;
        isGameStarted = false;
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }

        if (gameOver == true)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                SceneManager.LoadScene("Level");
            }
        }

        
        
        if (levelComplete == true)
        {
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("currentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
