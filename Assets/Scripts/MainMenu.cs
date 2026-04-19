
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscore;
    [SerializeField] private TextMeshProUGUI totalScore;

    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        totalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
        for (int i = 1; i <= 4; i++)
        {
            PlayerPrefs.SetInt($"Bat{i}", 1);
        }
    }

    public void StartGame()
    {
        MusicPlayer.instance.PlayClick();
        MusicPlayer.instance.PlayGameMusic();
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        MusicPlayer.instance.PlayClick();
        Application.Quit();
    }

    public void OpenMenu(GameObject menu)
    {
        MusicPlayer.instance.PlayClick();
        menu.SetActive(true);
    }

    public void ExitMenu(GameObject menu)
    {
        MusicPlayer.instance.PlayClick();
        menu.SetActive(false);
    }

    public void OpenWebpage(TextMeshProUGUI author)
    {
        switch (author.text)
        {
            case "brullov":
                Application.OpenURL("https://brullov.itch.io/");
                break;
            case "bagzie":
                Application.OpenURL("https://opengameart.org/users/bagzie");
                break;
            case "AgentDD":
                Application.OpenURL("https://freesound.org/people/AgentDD/");
                break;
            case "Mixkit":
                Application.OpenURL("https://mixkit.co/");
                break;
            case "AK":
                Application.OpenURL("https://uppbeat.io/browse/artist/ak");
                break;
            case "Narik The Artist":
                Application.OpenURL("https://nariktheartist.itch.io/");
                break;
            case "Craftron Gaming":
                Application.OpenURL("https://www.dafont.com/craftron-gaming.d6128");
                break;
        }
    }
}
