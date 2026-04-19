using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private AudioSource flap;
    [SerializeField] private AudioSource hit;
    [SerializeField] private float jumpSpeed;
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            hit.Play();
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            int newTotalScore = PlayerPrefs.GetInt("TotalScore") + gameController.scoreNum;
            PlayerPrefs.SetInt("TotalScore", newTotalScore);
            StartCoroutine(Death());
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!GameController.instance.gameOver && context.performed)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            GameController.instance.jumped = true;
            anim.Play("Flap");
            if (flap.isPlaying)
            {
                flap.Stop();
            }
            flap.Play();
            rb.linearVelocity = Vector2.zero;
        }
    }

    IEnumerator Death()
    {
        rb.linearVelocity = Vector2.zero;
        anim.SetBool("Dead", true);
        GameController.instance.gameOver = true;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
