using UnityEngine;
using System;
using UnityEngine.Events;


public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int hp = 100;
    
    public float ms = 2f;

    protected Transform player;
    
    [Header("Pengaturan State Machine")]
    [SerializeField] protected float jarakDeteksi = 4f;
    [SerializeField] protected float jarakSerang = 1.2f;
    [SerializeField] protected float jedaSerang = 1f;
    [SerializeField] private UnityEvent onZombieMatiVisual; 
    //Protected itu supaya variablenya boleh diakses oleh Enemy DAN anak-anaknya (seperti BossZombie)
    
    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;


    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        
        PeriksaTransisi();

        switch (state)
        {   
            case StateZombie.IDLE: PerilakuIdle(); break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE: PerilakuChase(); break;
            case StateZombie.ATTACK: PerilakuAttack(); break;
        }
    }

    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy menyerang!");
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        Debug.Log($"{gameObject.name} kena damage {jumlah}, HP sisa: {hp}");

        if (hp <= 0)
        {
            Mati();
        }
    }

    private void Mati()
    {
        Debug.Log($"{gameObject.name} mati!");
        OnZombieMati?.Invoke(this);
        onZombieMatiVisual?.Invoke(); 
        Destroy(gameObject);
    }

    public float JarakKePlayer()
    {
        if(player == null ) return Mathf.Infinity;
        return Vector2.Distance(transform.position,player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if(jarak <= jarakSerang)
            state = StateZombie.ATTACK;
        else if(jarak <= jarakDeteksi)
            state = StateZombie.CHASE;
        else
            state = StateZombie.PATROL;
    }
    public static event Action<Enemy> OnZombieMati;



    void PerilakuIdle()
    {
        Debug.Log("Aku Diam");
    }

    void PerilakuPatrol()
    {
        Debug.Log("Aku Patroli");
    }

    void PerilakuChase()
    {
        Kejar();
        Debug.Log("Aku Mengejar");
    }

    void PerilakuAttack()
    {
        Debug.Log("ROOOR!!!");
    }
}