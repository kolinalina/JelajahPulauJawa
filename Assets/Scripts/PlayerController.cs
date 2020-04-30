using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 5f;
    //int healthPoints = 3;
    bool isHurting, isDead;
    bool facingRight = true;
    Vector3 localScale;

    //sound
    private AudioSource MediaPlayerCoin;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 350f);

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 10f;
        else
            moveSpeed = 5f;

        SetAnimationState();

        if (!isDead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        if (!isHurting)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void SetAnimationState()
    {
        if (dirX == 0)
        {
            anim.SetBool("isWalking", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);

        if (Input.GetKeyDown("z") && Mathf.Abs(dirX) == 5)
        {
            anim.SetBool("isSliding", true);
        }
        if (Input.GetKeyUp("z") && Mathf.Abs(dirX) == 5)
        {
            anim.SetBool("isSliding", false);
        }
        //    else
        //    anim.SetBool("isSliding", false);
        //}
        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Water"))
        {
            anim.SetTrigger("isDead");
        }

        if (col.gameObject.tag.Equals("Shop"))
        {
           
            SceneManager.LoadScene("GirlLWin1");
            isDead = true;
        }

        if (col.gameObject.tag.Equals("Boy"))
        {
           
            SceneManager.LoadScene("GirlLVidioDialog2");
            isDead = true;
        }

    }

    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }

}
