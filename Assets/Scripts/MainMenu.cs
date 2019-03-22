using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
 
{


    void Start()
    {
        
    }

    void Update()
    {
        StartGame1Player();
        StartGame2Player();
    

    }
    void StartGame1Player()
    {
        if(Input.GetButtonDown("Start1"))
        {
            Debug.Log("One player start Game");
            SceneManager.LoadScene(1);
        }
    }

    public void StartGame2Player()
    {
        if (Input.GetButtonDown("Start2"))
        {
            Debug.Log("TWO player start Game");
            SceneManager.LoadScene(1);
        }
    }
}
