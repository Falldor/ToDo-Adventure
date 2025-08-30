using Unity.Mathematics;
using UnityEngine;

public class Magia : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private float velocidade = 2;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * velocidade * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("colision");
        collision.transform.GetComponent<Enemy>().DanoRecebido(1);
        
    }

    public void animationFinish()
    {
        Destroy(this.gameObject);
    }
}
