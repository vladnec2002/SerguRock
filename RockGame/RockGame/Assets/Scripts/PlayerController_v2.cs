using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_v2 : MonoBehaviour
{
    [SerializeField] float playerInputHorizontal;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float airJumpForce = 3;
    Rigidbody2D playerRb;
    [SerializeField] bool isOnGround;
    [SerializeField] GameObject mouseTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            playerRb.AddForce((mouseTarget.transform.position - transform.position * airJumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }
    }
}
