using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchiveControal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "archivePos")
        {
            Save();
            Load();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("anPosX", this.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("anPosY", this.gameObject.transform.position.y);
        PlayerPrefs.SetFloat("anPosZ", this.gameObject.transform.position.z);
    }

    private void Load()
    {
        float x = PlayerPrefs.GetFloat("anPosX");
        float y = PlayerPrefs.GetFloat("anPosY");
        float z = PlayerPrefs.GetFloat("anPosZ");

        Debug.Log("An Position:" + "(" + x + "," + y + "," + z + ")");
    }
}
