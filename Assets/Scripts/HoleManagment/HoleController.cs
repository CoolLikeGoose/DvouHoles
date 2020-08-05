using UnityEngine;
using UnityEngine.EventSystems;

public class HoleController : MonoBehaviour
{
    public float force = 300;
    [SerializeField] private float speed = 1f;
    Rigidbody cubeRB;
    
    [SerializeField] private bool isRightHole = false;

    private void Update()
    {
        //Из-за этого может на мобилках не работать
        if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.IsPointerOverGameObject(0)) { return; }
        if (Input.GetMouseButtonDown(0)) { GameManager.OnGameStart(); }

        //Удалить эти 3++ строки при релизе
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        if (!isRightHole) { movement = new Vector3(Input.GetAxis("HorizontalT"), 0, Input.GetAxis("VerticalT")) * speed * Time.deltaTime; }
        FingerController.Instance.CheckHolesDistances();
        transform.Translate(movement);

        Vector3 holePosition = transform.position;
        holePosition.x = Mathf.Clamp(holePosition.x, -4.3f, 4.3f);
        holePosition.z = Mathf.Clamp(holePosition.z, -13f, 5f);

        transform.position = holePosition;

    }

    private void OnTriggerStay(Collider other)
    {
        cubeRB = other.gameObject.GetComponent<Rigidbody>();
        cubeRB.isKinematic = false;
        //Pull cube if colors compare
        if (other.CompareTag(gameObject.tag) || other.CompareTag("Coin"))
        {
            Vector3 gravity = (transform.position - other.gameObject.transform.position) * force;
            cubeRB.AddForce(new Vector3(gravity.x, 0, gravity.z));
        }
        
    }
}
