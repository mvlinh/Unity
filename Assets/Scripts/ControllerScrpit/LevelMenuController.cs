 using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    [SerializeField] Button[] levelButton;

    int Level;

    private void Start()
    {
        Level = PlayerPrefs.GetInt("unlocklevel");

        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i <= Level)
            {
                levelButton[i].interactable = true;
            }
            else
                levelButton[i].interactable = false;
        }
        
       
    }
    public void GamePlay()
    {
       
        SceneManager.LoadScene(Level);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene((int)Scene.Menu);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
