using UnityEngine;

public class Bow : MonoBehaviour
{
    private Ray mouseRay1;
    private RaycastHit rayHit;
    // position of the raycast on the screen
    private float posX;
    private float posY;
    private float length;
    private Vector3 stringPullout;

    [Header("弦")]
    public Transform upperString;
    public Transform underString;
    public Vector3 BowMiddle;
    private LineRenderer bowString;

    [Header("弓矢")]
    public GameObject arrow;
    public GameObject arrowPrefab;
    Rigidbody2D arrowRig;
    float arrowStartPoditonX;

    public bool canShot = true;
    AudioSource sfx;
    // Use this for initialization
    void Start()
    {
        bowString = GetComponent<LineRenderer>();
        bowString.useWorldSpace = false;
        sfx = GetComponent<AudioSource>();
        arrowRig = arrow.GetComponent<Rigidbody2D>();
        arrowRig.simulated = false;
        arrowStartPoditonX = arrow.transform.localPosition.x;
        BowMiddle = (upperString.localPosition + underString.localPosition) / 2;
        stringPullout = BowMiddle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawBowString();
        arrowAngle();
        //弓を引く
        if (Input.GetMouseButton(0))
        {
            if (canShot == true)
            {
                prepareArrow();
            }
        }
        //弓を放つ
        if (Input.GetMouseButtonUp(0))
        {
            if (canShot == true)
            {
                ShotArrow();
            }
        }
    }

    void DrawBowString()
    {
        bowString.SetPosition(0, upperString.localPosition);
        //真ん中
        bowString.SetPosition(1, stringPullout);
        bowString.SetPosition(2, underString.localPosition);
    }

    public void prepareArrow()
    {
        //スクリーンをクリックした時のposition
        mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay1, out rayHit, 1000f))
        {
            // determine the position on the screen
            posX = this.rayHit.point.x;
            posY = this.rayHit.point.y;
            // 弓と矢に角度
            Vector2 mousePos = new Vector2(transform.position.x - posX, transform.position.y - posY);
            float angleZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angleZ);
            //弓を引く
            length = mousePos.magnitude / 3;
            //制限
            length = Mathf.Clamp(length, 0, 1);
            //弓を引いたときの矢の位置
            Vector2 arrowPosition = arrow.transform.localPosition;
            arrowPosition.x = (arrowStartPoditonX - length);
            arrow.transform.localPosition = arrowPosition;
            stringPullout = new Vector3(-(-0 + length), 0, 0);
        }
    }

    void ShotArrow()
    {
        arrowRig.simulated = true;
        arrowRig.AddForce(Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z)) * new Vector3(25f * length, 0, 0), ForceMode2D.Impulse);
        stringPullout = BowMiddle;
        sfx.Play();
        canShot = false;
    }

    public void createArrow()
    {
        arrow = Instantiate(arrowPrefab, BowMiddle, Quaternion.identity);
        SetArrow(arrow);
        canShot = true;
    }

    void SetArrow(GameObject _arrow)
    {
        arrow = _arrow;
        arrowRig = arrow.GetComponent<Rigidbody2D>();
        arrowRig.simulated = false;
        arrow.transform.localPosition = this.transform.position;
        arrow.transform.localRotation = this.transform.localRotation;
        arrow.transform.parent = this.transform;
    }

    void arrowAngle()
    {
        Vector3 vel = arrowRig.velocity;
        if (vel != Vector3.zero)
        {
            float angleZ = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
            float angleY = Mathf.Atan2(vel.z, vel.x) * Mathf.Rad2Deg;
            arrow.transform.eulerAngles = new Vector3(0, -angleY, angleZ);
        }
    }
}
