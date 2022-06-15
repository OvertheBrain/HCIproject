using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class adjuster : MonoBehaviour
{

    public Image col1,col2;

    static public Color color1,color2;
   
    public GameObject player;
    RobotController rc;

    public Slider r1,g1,b1,r2,g2,b2;
    // Start is called before the first frame update
    void Start()
    {
        rc=player.GetComponent<RobotController>();
    }

    public void StartGame(){
        SceneManager.LoadScene("PBRStageEquipmentDemo");
    }

    // Update is called once per frame
    void Update()
    {
        color1= new Color(r1.value,g1.value,b1.value);
        color2= new Color(r2.value,g2.value,b2.value);

        col1.color= color1;
        col2.color= color2;

        rc.col1=col1.color;
        rc.col2=col2.color;

        foreach(GameObject x in rc.c1_group){
            x.GetComponent<MeshRenderer>().materials[0].SetColor("_Color",rc.col1);
        }
        foreach(GameObject x in rc.c2_group){
            x.GetComponent<MeshRenderer>().materials[0].SetColor("_Color",rc.col2);
        }
    }
}
