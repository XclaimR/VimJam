using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 5.0f;
    public float holdSpeed = 2.5f;
    public bool isOnGround = false;
    public bool flipY;
    public float coolDown = 0.5f;
    public Cooldown cooldownbar;
    public EnemyScore es;
    public GameObject CollectibleLoc;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer mySpriteRenderer;
    private bool facingRight = false;
    private float nextFlipTime = 0f;
    public Animator animator;

    //Stuff Added...
    public bool onlyAffectPlayer = true;

    // Use this for initialization
    void Start()
    {
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        //You put this line on Update method, it's better to put it in Start!
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        cooldownbar.SetMaxValue(1 / coolDown);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Time.time >= nextFlipTime)
        {
            ChangeGravity();
        }
        else
        {
            cooldownbar.SetCoolDown(Time.time - (nextFlipTime - 1 / coolDown));
        }
    }

    void MovePlayer()
    {
        if (isOnGround)
        {
            float tempSpeed = speed;
            if (es.isHolding == true)
            {
                tempSpeed = holdSpeed;
            }
            else
            {
                tempSpeed = speed;
            }
            float translate = Input.GetAxis("2PHorizontal") * tempSpeed * Time.deltaTime;
            //Debug.Log(translate);
            
            if (translate < 0 && facingRight == true)
            {
                Flip();
            }
            else if (translate > 0 && facingRight == false)
            {
                Flip();
            }
            animator.SetFloat("is_Move", translate);
            _transform.Translate(-translate, 0, 0);
        }
    }

    void ChangeGravity()
    {
        //If you press W and you are grounded
        if ((Input.GetKeyDown(KeyCode.UpArrow) && isOnGround))
        {
            if (onlyAffectPlayer)
            {
                //Revert it's own gravity
                _rigidbody.gravityScale *= -1;

                //Flip the sprite
                _transform.Rotate(_rigidbody.gravityScale * 180f, 0f, 0f);
                //Debug.Log(mySpriteRenderer.flipY);
            }

            //Store your new value in your variable
            //flipY = mySpriteRenderer.flipY;
            //Cooldown to prevent smashing buttons
            nextFlipTime = Time.time + 1 / coolDown;
            cooldownbar.SetCoolDown(0);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        float temp = (-CollectibleLoc.transform.position.x + _transform.position.x) * 2 + CollectibleLoc.transform.position.x;
        CollectibleLoc.transform.position = new Vector3(temp, CollectibleLoc.transform.position.y, CollectibleLoc.transform.position.z);
        //Vector3 localScale = _transform.localScale;
        //_transform.Rotate(0f, 180f, 0f);
        //localScale.x *= -1;
        //_transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
            isOnGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isOnGround = false;
    }
}
