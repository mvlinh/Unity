using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static Door instance { get; private set; }

    [HideInInspector]
    public int colletableCount;

    private Animator anim;
    private BoxCollider2D box;
    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void DecrementCollectables()
    {
        colletableCount--;
        if(colletableCount == 0)
        {
            StartCoroutine(OpenDoor()); 
        }
    }

    IEnumerator OpenDoor()
    {
        anim.SetBool(GameTag.open, true);
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == GameTag.Player)
        {
           
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    GamePlayUI.Instance.PlayerDied();
                }
                else
                {
                    int unlockedLevel = PlayerPrefs.GetInt("unlocklevel");
                    if(unlockedLevel + 1 <  SceneManager.GetActiveScene().buildIndex)
                    {
                        PlayerPrefs.SetInt("unlocklevel", unlockedLevel + 1);
                    }
                    GamePlayUI.Instance.NextLevel();
                }
        }
    }
}
