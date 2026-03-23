using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject guidePanel;
    public GameObject playButton;
    public GameObject guideButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ShowGuide()
    {
        guidePanel.SetActive(true);

        // ẩn menu chính
        playButton.SetActive(false);
        guideButton.SetActive(false);
    }

    public void CloseGuide()
    {
        guidePanel.SetActive(false);

        // hiện lại menu
        playButton.SetActive(true);
        guideButton.SetActive(true);
    }
}