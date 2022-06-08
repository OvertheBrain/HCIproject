using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamController : MonoBehaviour
{
    // Start is called before the first frame update
     public Transform FollowObject;  //被跟随的物体
    private Vector2 MouseStart, MouseEnd;
    private Vector3 DeltAngle,DeltAngle2;
    public float CameraDistence = 100;   //相机与其跟随物体保持的距离
    public GameObject robot;
    private float delt, deltz;
    private float PI = 3.14159f;
    private Vector3 DeltPosition;
    private bool IsDrag = false;
 
    void Start() {
        DeltAngle = gameObject.transform.localEulerAngles;
        DeltAngle2 = robot.transform.localEulerAngles;
    }

 
    void LateUpdate() {
        if (IsDrag) {
            MouseStart = MouseEnd;
            MouseEnd = Input.mousePosition;
            DeltAngle.x -= (MouseEnd.y - MouseStart.y) / 50;
            DeltAngle2.y += (MouseEnd.x - MouseStart.x) / 7;
           
            robot.transform.localEulerAngles=new Vector3(0,DeltAngle2.y,0);
            transform.localEulerAngles=new Vector3(DeltAngle.x,180,0);
            deltz = DeltAngle.x * PI / 180;
            gameObject.transform.localPosition= new Vector3(0, CameraDistence * Mathf.Sin(deltz), -CameraDistence * Mathf.Cos(deltz));
        }
    }
    void OnGUI() {
        if (Event.current.type == EventType.MouseDown) MouseEnd = Input.mousePosition;
        if (Event.current.type == EventType.MouseDrag) IsDrag = true;
        if (Event.current.type == EventType.MouseUp) IsDrag = false;
    }

}
