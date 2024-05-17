using TMPro;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    public float speed;

    int direction = 1;
    Rigidbody rigidBody;

    bool hasHit;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Debug.Log("Kinematic ON");
    }

    void Update()
    {
        //Forma 1 de movimentação (Sem física)
        /*transform.Translate(new Vector3(1f, 0f, 0f) 
            * direction 
            * Time.deltaTime 
            * speed);*/

        if(transform.position.y < -2f)
        {
            SpawnerController.Instance.SpawnObject();
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //Forma 2 de movimentação (Com física)
        /*rigidBody.velocity = Vector3.right
            * direction
            * speed;*/

        //Forma 3 - (Com física)
        //rigidBody.MovePosition(Vector3)

        //Forma 4 - (Com física)
        //rigidBody.Move(Vector3, Quaternion)
        if (!hasHit)
        {
            rigidBody.Move(transform.position + new Vector3(1f, 0f, 0f)
            * direction
            * Time.fixedDeltaTime
            * speed,
            Quaternion.identity);


            if (transform.position.x >= 4 && direction > 0
                || transform.position.x <= -4 && direction < 0)
            {
                direction = -direction;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hasHit = true;
            UIController.Instance.IncreaseScore();
        }
    }
}
