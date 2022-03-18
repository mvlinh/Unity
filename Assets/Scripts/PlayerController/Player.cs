using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerBullet playerBullet;

    private static Player instance;
    public static Player Instance => instance;
    [Header("JoyStick")]
    public Joystick1 joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool conFisicas;

    [Header("Move")]
    public float JumForce = 500f;
    public float maxVelocity = 4f;
    public float moveForce = 10f;
    public float forceX = 0f;
    public int h;
    private bool moveLeft, moveRight;
    private bool leftdirection;
    private bool grouned = false;
    private Rigidbody2D myBody;
    private Animator anim;
    public Transform firePoint;
    public Vector3 scale;
    public Vector3 direction;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //CheckForPickUp();
    }
    private void FixedUpdate()
    {
       
        if(joystick.Horizontal == 0)
        {
            anim.SetBool(GameTag.PlayerWalkAnim, false);
        }
        else
        {
            Vector2 direction = Vector2.right * joystick.Horizontal / Mathf.Abs(joystick.Horizontal);
            gameObject.transform.Translate(direction * velocidad * Time.fixedDeltaTime);
            leftdirection = joystick.Horizontal < 0 ? true : false;
            h = joystick.Horizontal > 0 ? 1 : -1;
            forceX = h * moveForce;
            scale = transform.localScale;
            scale.x = h;
            transform.localScale = scale;
            anim.SetBool(GameTag.PlayerWalkAnim, true);
        }
        if(joystick.Vertical > 0.5)
        {
            if (grouned)
            {
                float forceY = JumForce;
                grouned = false;
                myBody.velocity = Vector2.zero;
                myBody.AddForce(new Vector2(0, forceY));

            }
        }
    }
    public void PlayerWalkJoyStick()
    {
        if (moveLeft)
        {
            h = -1;
            leftdirection = true;
        }

        else if (moveRight)
        {
            h = 1;
            leftdirection = false;
        }
        else
            h = 0;

        if (h == 0)
        {
            anim.SetBool(GameTag.PlayerWalkAnim, false);
        }
        else
        {
            anim.SetBool(GameTag.PlayerWalkAnim, true);

        }
      
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }
     public void StopMoving()
    {
        this.moveLeft = false;
        this.moveRight = false;
    }

    public void Jump()
    {
        if (grouned)
        {
            float forceY = JumForce;
            grouned = false;
            myBody.velocity = Vector2.zero;
            myBody.AddForce(new Vector2(0, forceY));

        }
    }
    void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");

        if (h == 0)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            forceX = h * moveForce;
            Vector3 scale = transform.localScale;
            scale.x = h;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        myBody.velocity = new Vector2(forceX, myBody.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            if (grouned)
            {
                grouned = false;
                forceY = JumForce;
                myBody.AddForce(new Vector2(forceX, forceY));

            }
        }

    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == GameTag.Ground)
        {
            grouned = true; 
            anim.SetBool(GameTag.Ground, true);
        }   
        else if( target.gameObject.tag == GameTag.Die)      
        {
            GamePlayUI.Instance.PlayerDied();
        }
    }
    public void BouncePlayerWithBouncy(float force)
    {
        if (grouned)
        {
            grouned = false;
            myBody.AddForce(new Vector2(0,force));
        }
        
    }
    private void CheckForPickUp()
    {


#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (leftdirection)
                {
                    SpawnBullet(transform.right * (-1) * 20f);
                }
                else
                    SpawnBullet(transform.right * 20f);

            }
           
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if(leftdirection)
                {
                    SpawnBullet(transform.right * (-1) * 20f);
                }
                else
                    SpawnBullet(transform.right * 20f);
            }

        }
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(1).fingerId))
            {
                 if(leftdirection)
                {
                    SpawnBullet(transform.right * (-1) * 20f);
                }
                else
                    SpawnBullet(transform.right * 20f);
            }
        }
#endif
    }
    public void Shoot()
    {
        if (leftdirection)
        {
            SpawnBullet(transform.right * (-1) * 20f);
        }
        else
            SpawnBullet(transform.right * 20f);
    }
    private void SpawnBullet(Vector2 dir)
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            PlayerBullet playerbullet = Instantiate(playerBullet, transform.position , Quaternion.identity);
            playerbullet.Active(dir);
        }
    }
}
