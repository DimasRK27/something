using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float MovementSpeed = 4;
    public float Jumpforce = 4;

    private Rigidbody2D _rigidbody;
    public Animator animator;
    public Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    var movement = Input.GetAxis("Horizontal") * MovementSpeed;
    transform.position += new Vector3(movement, 0, 0) * Time.deltaTime ;
    animator.SetFloat("isWalking", Mathf.Abs(movement));
        if (!Mathf.Approximately(0, movement))
        {

            transform.rotation = -movement > 0 ? Quaternion.Euler(0,-200,0) : Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.X) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
            
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "platform")
        {
            animator.SetBool("isJump", false);
        }
    }

}
