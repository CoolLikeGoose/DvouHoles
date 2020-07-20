using UnityEngine;
using UnityEngine.EventSystems;

public class FingerController : MonoBehaviour
{
    //Only for PC controls
    public static FingerController Instance { get; private set; }

    [SerializeField] private GameObject holeOne;
    [SerializeField] private GameObject holeTwo;
    private GameObject currentHole;

    private Vector3 holeOneStartPos;
    private Vector3 holeTwoStartPos;

    [SerializeField] private float speed;

    private Vector2 previousPos;
    private Vector2 direction;
    
    [SerializeField] private float lerpFactor = 0.5f;

    [Tooltip("3 - нормальное значиние, 2 - вплотную")]
    [SerializeField] private float minDistanceBetweenHoles = 3f;

    private bool isReadyForMovement;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        holeOneStartPos = holeOne.transform.position;
        holeTwoStartPos = holeTwo.transform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        isReadyForMovement = false;
                        return;
                    }

                    GameManager.OnGameStart();
                    if (touch.position.x > Screen.width / 2f) { currentHole = holeOne; }
                    else { currentHole = holeTwo; }

                    previousPos = touch.position;

                    isReadyForMovement = true;
                    break;  

                case TouchPhase.Moved:
                    //Fix steps
                    //just stop normilizing direction
                    //magnitude < 0.8 => break
                    if (!isReadyForMovement) { break; }
                    direction = touch.position - previousPos;

                    currentHole.transform.Translate(FixDirection(direction) * Time.deltaTime * speed);

                    CheckHolesDistances();
                    RestrictHoleMovement();

                    previousPos = Input.mousePosition;
                    break;

                case TouchPhase.Ended:
                    holeOne.transform.position = holeOneStartPos;
                    holeTwo.transform.position = holeTwoStartPos;
                    break;
            }
        }
    }

    private Vector3 FixDirection(Vector3 directionT)
    {
        //directionT.Normalize();
        directionT.z = directionT.y;
        directionT.y = 0;

        return directionT;
    }

    public void RestrictHoleMovement()  
    {
        Vector3 holePosition = currentHole.transform.position;
        holePosition.x = Mathf.Clamp(holePosition.x, -4.3f, 4.3f);
        holePosition.z = Mathf.Clamp(holePosition.z, -13f, 5f);

        currentHole.transform.position = holePosition;

        //Это управление под пк, ток еще в дыркаконтроллер вызов этого метода добавьтеы
        //Vector3 holePosition = holeTwo.transform.position;
        //holePosition.x = Mathf.Clamp(holePosition.x, -4.3f, 4.3f);
        //holePosition.z = Mathf.Clamp(holePosition.z, -13f, 5f);

        //holeTwo.transform.position = holePosition;
    }

    public void CheckHolesDistances()
    {
        if (Vector3.Distance(holeOne.transform.position, holeTwo.transform.position) < minDistanceBetweenHoles)
        {
            //add animation for this
            holeOne.transform.position = holeOneStartPos;
            holeTwo.transform.position = holeTwoStartPos;
        }
    }
}
