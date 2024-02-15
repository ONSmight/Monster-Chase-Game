using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float walkforce = 10f;
    float moveX = 0f;
    public float jumpforce = 11f;
    SpriteRenderer sp;
    string WalkAnim = "Walk";
    bool IsGrounded;
    Animator anim;
    Rigidbody2D rb;

	private void Awake()
	{
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void  Update()
    {
        PlayerMove();
        Jump();
    }
    private void PlayerMove()
    {
        //Boundries
        if (transform.position.x >= 64.8f)
        {
            transform.position = new Vector2(64.8f, transform.position.y);
        }
        if (transform.position.x <= -67.5f)
        {
            transform.position = new Vector2(-67.5f, transform.position.y);
        }

        moveX = Input.GetAxisRaw("Horizontal");
        if (moveX > 0)
        {
            sp.flipX = false;
            anim.SetBool(WalkAnim, true);
        }
        else if (moveX < 0)
        {
            sp.flipX = true;
            anim.SetBool(WalkAnim, true);
        }
        else { anim.SetBool(WalkAnim, false); }
        transform.position += new Vector3(moveX, 0f, 0f) * walkforce * Time.deltaTime;
    }
    void Jump() 
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsGrounded = false;
            rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);

        }
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
	}

}//class











