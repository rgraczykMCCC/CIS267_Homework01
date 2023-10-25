using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public GameObject gameManager;
    private GameManager gm;

    public float speed;
    private float inputX;

    //public Vector2 jumpHeight;
    //private float moveInput;
    //public float speed;
    private float playerYPosition;
    public float timeToShrink;
    private int rocketJumpCount;
    public int positionScore;
    private bool hasRocket;
    private bool isScaled;
    public bool hitClock;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        playerYPosition = transform.position.y;
        
        playerDirection();
        setPlayerYPosition();
    }

    private void playerDirection()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector2.right * -5);
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector2.left * -5);
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }

    public float getPlayerYPostion()
    {
        return playerYPosition;
    }

    private void setPlayerYPosition()
    {
        playerYPosition = transform.position.y;
        //Debug.Log("Player Y Pos: " + playerYPosition);
    }

    public void playerPositionScore()
    {
        GetComponent<Score>().setScore(positionScore);
    }

    public int getFinalScore()
    {
        return GetComponent<Score>().getScore();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hasRocket: " + hasRocket);

        //checks if the player is moving up or down. If it's moving down, we can jump again
        if (collision.gameObject.tag.Equals("Airplane") && rb.velocity.y <= 1)
        {
            if (hasRocket == true && rocketJumpCount > 0)
            {
                rb.AddForce(Vector2.up * 1800f);
                hasRocket = false;
                rocketJumpCount--;
            }
            else
            {
                hasRocket = false;
                rb.AddForce(Vector2.up * 900f);    //600
            }
            //Debug.Log("found ground");
        }

        else if (collision.gameObject.tag.Equals("Ground") && rb.velocity.y <= 1)
        {
            if (hasRocket == true && rocketJumpCount > 0)
            {
                rb.AddForce(Vector2.up * 1800f);
                hasRocket = false;
                rocketJumpCount--;
            }
            else
            {
                hasRocket = false;
                rb.AddForce(Vector2.up * 900f);
            }
            //Debug.Log("found ground");
        }
        //if (collision.gameObject.tag.Equals("Player") && )

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Lightning") || collision.gameObject.CompareTag("Rocket") || collision.gameObject.CompareTag("Clock"))
        {
            if (collision.gameObject.CompareTag("Lightning"))
            {
                Debug.Log("Player hit lightning");
                int addToScore = collision.GetComponent<Lightning>().getValue();
                GetComponent<Score>().setScore(addToScore);
                collision.GetComponent<Lightning>().destroyLightning();
                playerSize(1);
            }

            else if (collision.gameObject.CompareTag("Rocket"))
            {
                rocketJumpCount = 1;
                Debug.Log("Player has rocket");
                hasRocket = true;
                int addToScore = collision.GetComponent<Rocket>().getValue();
                GetComponent<Score>().setScore(addToScore);
                collision.GetComponent<Rocket>().destroyRocket();
            }

            else if (collision.gameObject.CompareTag("Clock"))
            {
                int addToScore = collision.GetComponent<Clock>().getValue();
                GetComponent<Score>().setScore(addToScore);
                setAddToClock(true);
                collision.GetComponent<Clock>().destroyClock();
            }
        }
        
        else if (collision.gameObject.CompareTag("Helicopter") || collision.gameObject.CompareTag("Missile"))
        {
            Debug.Log("Helicopter or Missile hit player");
            gm.setGameOver(true);
        }

        else if (collision.gameObject.CompareTag("Destroyer"))
        {
            gm.setGameOver(true);
        }
    }

    public void playerSize(int size)
    {
        // size = 1, player shrinks
        if (size == 1 && !isScaled)
        {
            Debug.Log("Player shrinking");
            Vector2 scaleMultiple = new Vector2(0.75f, 0.75f);
            isScaled = true;
            setPlayerScale(scaleMultiple);

        }

        // size = 2, player grows
        if (size == 2 && !isScaled)
        {
            Debug.Log("Player growing");
            Vector2 scaleMultiple = new Vector2(2f, 2f);
            isScaled = true;
            setPlayerScale(scaleMultiple);
        }
    }

    public void setPlayerScale(Vector2 scaleMultiple)
    {
        // get original scale so we return the this size after the effect wears off
        Vector2 originalScale = transform.localScale;


        //Debug.Log("Original scale: " + transform.localScale.x + ", " + transform.localScale.y);
        // grow or shrink player depending on the size sent from Game Manager, which depends on the collectable
        transform.localScale = new Vector2(originalScale.x * scaleMultiple.x, originalScale.y * scaleMultiple.y);
        //Debug.Log("New Scale: " + transform.localScale.x + ", " + transform.localScale.y);

        //start timer for 5 seconds, send the original scale to return player to that size.
        StartCoroutine(PlayerScaleTimer(originalScale));
    }

    public void setAddToClock(bool c)
    {
        hitClock = c;
    }

    public bool getAddToClock()
    {
        return hitClock;
    }


    IEnumerator PlayerScaleTimer(Vector2 originalScale)
    {
        //wait for 5 seconds
        yield return new WaitForSeconds(3);
        //Debug.Log("Waited for 5 seconds");

        // return player to original size
        transform.localScale = originalScale;
        //Debug.Log("Reset Scale: " + transform.localScale.x + ", " + transform.localScale.y);
        isScaled = false;
    }
}
