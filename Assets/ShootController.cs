using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bullet;
    public float shootPower;
    public Transform bulletPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
             * 1. Instanciar bala
             * 2. Atirar a bala
             **/

            var bulletObject = Instantiate(bullet, bulletPivot.position, 
                Quaternion.identity);
            var bulletRidigBody = bulletObject.GetComponent<Rigidbody>();
            bulletRidigBody.AddForce(new Vector3(0f, 1f, 1f) * shootPower);
        }
    }
}
