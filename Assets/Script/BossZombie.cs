using UnityEngine;


public class BossZombie : Enemy
{
    [SerializeField] private ZombieConfig config;

    protected override void Start()
    {
        base.Start(); // tetap jalankan Start() bawaan dari Enemy dulu

        if (config != null)
        {
            hp = config.hp;
            ms = config.kecepatan;
            jarakDeteksi = config.jarakDeteksi;
            jarakSerang = config.jarakSerang;
        }
    }
}