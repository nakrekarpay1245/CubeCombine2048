using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointText;

    [SerializeField]
    private GameObject restartButton;

    private int point;

    public static Manager manager;

    private void Awake()
    {
        if (!manager)
        {
            manager = this;
        }
        Time.timeScale = 1;
    }

    public void Score(int value)
    {
        point += value;
        pointText.text = "POINT: " + point;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateRestartButton()
    {
        restartButton.SetActive(true);
    }
}
