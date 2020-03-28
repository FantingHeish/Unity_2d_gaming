using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //public GameObject menuContaner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        Blood.blood = 3;
        Blood.score = 0;
        SceneManager.LoadScene("SampleScene");
        //menuContaner.SetActive(false);
    }
}
