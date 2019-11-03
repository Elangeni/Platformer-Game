using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Start Scene")
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (scene.name == "You Win")
            {
                SceneManager.LoadScene("Start Scene");
            }
            else if (scene.name == "You Lose")
            {
                SceneManager.LoadScene("Start Scene"); 
            }
        }
    }
}
