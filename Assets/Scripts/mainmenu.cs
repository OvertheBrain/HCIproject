using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void QuickStart(){
        SceneManager.LoadScene("init");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
