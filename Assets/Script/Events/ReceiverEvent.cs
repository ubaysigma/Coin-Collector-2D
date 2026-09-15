using UnityEngine;

public class ReceiverEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        PemancarEvent.TekanTombol += TampilPesan;
    }

    void OnDisable()
    {
        PemancarEvent.TekanTombol -= TampilPesan;
    }
    void TampilPesan()
    {
        Debug.Log("ReceiverEvent menerima event tekan Tombol");
    }
}
