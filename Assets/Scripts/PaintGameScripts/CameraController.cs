using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Vector2 startPos;
    private Camera cam;
    private Vector3 direction;
    private Vector2 previousPos;
    public float speed = 1;
    private Vector3 pos1, pos2;
    float timer = 0f;
    bool move = false, TimerInc = false;
    //private bool isMoving = false;
    private void Start()
    {
        cam = GetComponent<Camera>();
        pos1 = transform.position;
        pos2 = transform.position;
    }
    public void ChangeScene(int id)//тебя не трогает, и ты не трогай
    {
        SceneManager.LoadScene(id);
    }
    private void Update()
    {
        if (TimerInc)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            pos1 = Input.mousePosition;
            TimerInc = true;
            timer = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pos2 = Input.mousePosition;
            TimerInc = false;
            timer = 0;
            move = false;
        }
        if(timer >= 0.2f)
        {
            move = true;
        }
        if (move && Input.GetMouseButton(0))
        { 
        
            direction = (Vector2)Input.mousePosition - previousPos;
            transform.Translate(direction * Time.deltaTime * speed);
            previousPos = Input.mousePosition;
            move = false;
        }

        if (transform.position.x > lvls.maxx) transform.position = new Vector3(lvls.maxx, transform.position.y, transform.position.z);
        if (transform.position.x < lvls.minx) transform.position = new Vector3(lvls.minx, transform.position.y, transform.position.z);
        if (transform.position.y > lvls.maxy) transform.position= new Vector3(transform.position.x, lvls.maxy, transform.position.z);
        if (transform.position.y < lvls.miny) transform.position = new Vector3(transform.position.x, lvls.miny, transform.position.z);



        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("chlen1");
        //    startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        //}
        //else if (Input.GetMouseButton(0))
        //{

        //    float posx = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
        //                    Debug.Log(Input.mousePosition);
        //                              Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition).x);
        //    transform.position = new Vector3(transform.position.x - posx, transform.position.y, transform.position.z);
        // float posy = cam.ScreenToWorldPoint(Input.mousePosition).y - startPos.y;
        // transform.position = new Vector3(transform.position.x, transform.position.y - posy, transform.position.z);
        //}
    }
    
}
