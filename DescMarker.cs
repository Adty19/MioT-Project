using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescMarker : MonoBehaviour
{
    [Header("Deskripsi Objek")]
    public TrackableAR[] tr;
    [TextArea]
    public string[] deskripsi;

    [Header("UI Deskripsi")]
    public Text txtDeskripsi;
    public GameObject goDeskripsi;

    public bool[] cekMarker;
    int countMarker;

    void Start()
    {
        cekMarker = new bool[tr.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tr.Length; i++)
        {
            if (tr[i].GetMarker())
            {
                txtDeskripsi.text = deskripsi[i];

                if (!cekMarker[i])
                {
                    countMarker++;
                    cekMarker[i] = true;
                }
            }
            else
            {
                if (cekMarker[i])
                {
                    countMarker--;
                    cekMarker[i] = false;
                }
            }
        }

        DeskripsiPanel();
    }

    private void DeskripsiPanel()
    {
        if (countMarker == 0)
        {
            goDeskripsi.SetActive(false);
        }
        else
        {
            goDeskripsi.SetActive(true);
        }
    }
}
