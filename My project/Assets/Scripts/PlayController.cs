using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum characterEnum
{
    speedUp,
    giant
}
public class PlayController : MonoBehaviour
{
    [Header("---------Information--------")]
    [SerializeField] float minSpeed = 5f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float[] time_spawn;
    float speed;
    float[] _time_spawn;

    Animator animator;
    Rigidbody2D rigidbody2;

    Vector2 inputMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        speed = minSpeed;

        _time_spawn = new float[time_spawn.Length];
        for(int i=0; i<time_spawn.Length; i++)
            _time_spawn[i] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Move();
    }
    void CheckInput()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            inputMovement.x = -1;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputMovement.x = 1;
        }
        else
        {
            inputMovement.x = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputMovement.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            inputMovement.y = -1;
        }
        else
        {
            inputMovement.y = 0;
        }
        KeyCode[] inputKey = { KeyCode.Q, KeyCode.W, KeyCode.E };
        for(int i=0; i<inputKey.Length; i++)
        {
            if (_time_spawn[i] > 0)
            {
                _time_spawn[i] -= Time.deltaTime;
            }else if (Input.GetKeyDown(inputKey[i]))
            {
                Character((characterEnum)i);
            }
        }

    }
    void Move()
    {
        rigidbody2.velocity = inputMovement*speed;
    }
    void Character(characterEnum value)
    {
        switch(value)
        {
            case characterEnum.speedUp:
                {
                    animator.SetBool("isMoving", true);
                    speed = maxSpeed;
                    break;
                }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Die");
            animator.SetFloat("typeDeath", (int)Random.Range(0, 2));
        }
    }
}
