using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float speed;
    public bool disabled = false;

    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer rend;
    private Animator anim;
    private Vector2 movement;
    private Vector2 clampedMovement;
    private Vector2 lastLookDirection;
    private bool SpriteFacingRight = true;
    private EventInstance playerFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>(); //Get Collider component
        rend = GetComponent<SpriteRenderer>(); //Get Sprite Renderer Component
        anim = GetComponent<Animator>();
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            rb.velocity = speed * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            Animate();
            FlipCheck(Input.GetAxisRaw("Horizontal"));
            /*if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                lastLookDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }*/
        }
        if(disabled)
        {
            rb.velocity = Vector2.zero;
        }
        Animate();
        FlipCheck(Input.GetAxisRaw("Horizontal"));
        UpdateSound();
    }

    public void DisablePlayer(bool isDisabled)
    {
        disabled = isDisabled;
        if (disabled)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }
    }
    private void FlipCheck(float move)
    {
        //Flip the sprite so that they are facing the correct way when moving
        if (move > 0 && !SpriteFacingRight) //if moving to the right and the sprite is not facing the right.
        {
            Flip();
        }
        else if (move < 0 && SpriteFacingRight) //if moving to the left and the sprite is facing right
        {
            Flip();
        }
    }

    private void Flip()
    {
        SpriteFacingRight = !SpriteFacingRight; //flip whether the sprite is facing right
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    private void UpdateSound()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            PLAYBACK_STATE footsteps;
            playerFootsteps.getPlaybackState(out footsteps);
            if (footsteps.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
            //Debug.Log(footsteps);
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
            //Debug.Log("False");
        }
    }

    private void Animate()
    {
        anim.SetFloat("MoveHorizontal", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveVertical", Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Horizontal") != 0 || rb.velocity.y != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
