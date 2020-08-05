using UnityEngine;
using UnityEngine.EventSystems;

public class CameraSmoothMov : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    private Vector2 startPos;
    private Camera cam;

    //private float targetPos;
    private Vector3 targetPos;

    private float startDist;
    private float startSize;

    private bool canMove = true;

    private float constSize;

    private void Start()
    {
        cam = GetComponent<Camera>();

        transform.position = new Vector3(PaintController.Instance.cameraPos, PaintController.Instance.cameraPos, -10);
        cam.orthographicSize = PaintController.Instance.cameraSize;
        constSize = cam.orthographicSize;
        targetPos = transform.position;

        Vector3 reloadCamPos = transform.position;
        float reloadCamSize = cam.orthographicSize;
        PaintController.OnPaintingEnd += () =>
        {
            canMove = false;
            transform.position = reloadCamPos;
            cam.orthographicSize = reloadCamSize;
        };
    }

    private void Update()
    {
        if (!canMove) { return; }
        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            if (secondTouch.phase == TouchPhase.Began)
            { 
                startDist = Vector2.Distance(firstTouch.position, secondTouch.position);
                startSize = cam.orthographicSize;
            }

            float size = startSize * startDist / Vector2.Distance(firstTouch.position, secondTouch.position);
            cam.orthographicSize = Mathf.Clamp(size, 2.5f, constSize*1.5f);

            return;
        }

        //movement
        if (Input.GetMouseButtonDown(0) || EventSystem.current.IsPointerOverGameObject())
        {
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {   
            Vector2 pos;
            //Пойду сдохну!1!!11)))))
            pos.x = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
            pos.y = cam.ScreenToWorldPoint(Input.mousePosition).y - startPos.y;

            targetPos.x = Mathf.Clamp(transform.position.x - pos.x, -3 * (constSize / 10), 12 * (constSize / 10));
            targetPos.y = Mathf.Clamp(transform.position.y - pos.y, -3 * (constSize / 10), 12 * (constSize / 10));
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos.x, speed * Time.deltaTime),
                                            Mathf.Lerp(transform.position.y, targetPos.y, speed * Time.deltaTime),
                                            transform.position.z);
    }
}
