using UnityEngine;
using System;
public class BelajaraDelegate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public delegate void AksiDelegate();
    void Start()
    {
        CobaDelegate1();
        CobaDelegate2();
        CobaDelegate3();
    }
    void CobaDelegate1()
    {
        AksiDelegate halo = PanggilHalo;
        halo += PanggilWorld;
        halo();
    }
    void CobaDelegate2()
    {
        AksiDelegate halo = PanggilHalo;
        halo += PanggilWorld;
        halo();
    }
    void CobaDelegate3()
    {
        AksiDelegate halo = PanggilHalo;
        halo += PanggilWorld;
        halo();
    }
    void PanggilHalo()
    {
        Debug.Log("Halo");

    }
    void PanggilWorld()
    {
        Debug.Log("World");
    }
}
