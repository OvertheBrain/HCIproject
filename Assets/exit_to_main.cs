using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_to_main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Click()
    {
        SceneManager.LoadScene("Main_menu", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
