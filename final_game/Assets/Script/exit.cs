using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void EXIT()
    {
        SceneManager.LoadSceneAsync(0);
        //Application.Quit();
    }
    public void start()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
