using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicGameController : MonoBehaviour
{
    public float baselineposy=-200;
    public int score=0;
    public Text scoreBoard;

    public GameObject note;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text=score.ToString();
    }

    public void Launch(){
        Vector3 spawnPosition = new Vector3(450,400,0);
        GameObject go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="right";
        go.transform.SetParent(canvas.transform, false);
        spawnPosition = new Vector3(-450,600,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="left";
        go.transform.SetParent(canvas.transform, false);

        spawnPosition = new Vector3(450,800,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="right";
        go.transform.SetParent(canvas.transform, false);

        spawnPosition = new Vector3(-450,1000,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="left";
        go.transform.SetParent(canvas.transform, false);

        spawnPosition = new Vector3(450,1300,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="right";
        go.transform.SetParent(canvas.transform, false);

        spawnPosition = new Vector3(-450,1300,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="left";
        go.transform.SetParent(canvas.transform, false);

        spawnPosition = new Vector3(450,1600,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="right";
        go.transform.SetParent(canvas.transform, false);

        spawnPosition = new Vector3(-450,1600,0);
        go = Instantiate(note, spawnPosition,Quaternion.identity);
        go.GetComponent<noteController>().type="left";
        go.transform.SetParent(canvas.transform, false);
    }

    public void Hit(string type){
        GameObject[] notes=GameObject.FindGameObjectsWithTag("Note");
        foreach(GameObject note in notes){
            noteController nc=note.GetComponent<noteController>();
            float accuracy=Mathf.Abs(nc.posy-baselineposy);
            if( accuracy<100 && type==nc.type && nc.state==false){
                nc.state=true;
                score+=(int)accuracy;
            }
        }
    }
}
