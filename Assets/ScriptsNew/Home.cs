using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    [SerializeField] private GameObject uiWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(controller.hasKey == true)
            {
                uiWin.SetActive(true);
            }
            else
            {
                Debug.Log("Want a Key");
            }
        }
    }
}
