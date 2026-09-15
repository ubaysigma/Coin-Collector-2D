using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float kecepatan = 5f;
    public int skor = 0;

    private Vector2 arahGerak; 
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    void OnMove(InputValue value)
    {
        arahGerak = value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 arah = new Vector3(arahGerak.x,arahGerak.y, 0);
        transform.position += arah * kecepatan * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //mengecek apakah yang disentuh memiliki tag "Coin"
        if(other.CompareTag("Coin"))
        {
            //jika memiliki maka coin itu akan dihancurkan
            Destroy(other.gameObject);
            skor += 1 ;
            Debug.Log("Score = "+ skor);

            if(gameManager != null)
            {
                gameManager.AmbilKoin();
            }else{
                Debug.Log("Game Manager Tidak ditemukan");
            }
        }
    }
}
