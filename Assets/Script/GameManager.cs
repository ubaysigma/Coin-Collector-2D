using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalKoin;
    private int koinTerkumpul = 0;
    [SerializeField] private int skor = 0;

    void Start()
    {
        // Hitung jumlah koin di scene
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("Total Koin : "+totalKoin);
    }

    void OnEnable()
    {
        Enemy.OnZombieMati += TambahSkorSaatZombieMati;
    }

    void OnDisable()
    {
        Enemy.OnZombieMati -= TambahSkorSaatZombieMati;
    }

    void TambahSkorSaatZombieMati(Enemy zombieyangmati)
    {
        skor += 10;
        Debug.Log(skor);
    }

    public void AmbilKoin()
    {
        koinTerkumpul++;
        Debug.Log("Koin Diambil "+koinTerkumpul+"/"+totalKoin);

        if (koinTerkumpul == totalKoin)
            {
            Menang();
            }
            
    }

    void Menang()
    {
        Time.timeScale = 0f;
        Debug.Log("KAMU MENANG!");
        
    }
}
