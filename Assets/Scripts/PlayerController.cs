using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Atk = 5, Hp = 50;
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private GameObject uiInventory; // อ้างอิงถึง UI Inventory
    private bool uiInventoryActive = false; // สถานะเปิด/ปิด UI Inventory

    //[SerializeField] private Inventory inventory;
    private Collider2D currentTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        uiInventory.SetActive(false);
        
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontalInput, verticalInput);
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventoryUI(!uiInventoryActive);
        }
    }

    private void ToggleInventoryUI(bool isActive)
    {
        uiInventory.SetActive(isActive);
        uiInventoryActive = isActive;
    }

    private void FixedUpdate()
    {
        // เคลื่อนที่ Player
        rb.velocity = movement * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wood") || collision.CompareTag("Stone"))
        {
            currentTarget = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == currentTarget)
        {
            currentTarget = null;
        }
    }

    private void CollectItem(Item item)
    {
        if (item != null)
        {
            //inventory.AddItem(item);
            Destroy(item.gameObject);
        }
    }
}
