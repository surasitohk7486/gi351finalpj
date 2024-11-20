using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int wood = 5, stone = 5, hpPt = 0, sword,armor;
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool uiCraftActive = false;
    
    

    public GameObject flashlight; // อ้างอิงถึงไฟฉาย
    public float flashlightDistance = 1f; // ระยะห่างของไฟฉายจาก Player
    private bool isFlashlightOn = false; // ตรวจสอบสถานะเปิด/ปิดของไฟฉาย
    private bool isFacingUp = true; // ตรวจสอบว่าผู้เล่นหันไปทางบนหรือล่าง

    [SerializeField] private Inventory inventory;
    private Collider2D currentTarget;

    [SerializeField] private GameObject uiCrafting;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
        

        ToggleCraftingUI(false);

        // ตั้งค่าให้ไฟฉายปิดในตอนเริ่มเกม
        if (flashlight != null)
        {
            flashlight.SetActive(isFlashlightOn);
        }
    }

    private void Update()
    {
        // รับค่า Input จากผู้เล่น
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontalInput, verticalInput);

        // ตรวจสอบการกดคลิกซ้ายเพื่อเปิด/ปิดไฟฉาย
        if (Input.GetMouseButtonDown(0)) // 0 คือคลิกซ้าย
        {
            ToggleFlashlight();
        }

        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            CollectItem(currentTarget.GetComponent<Item>());
        }

        // กด E เพื่อเปิด/ปิด UI คราฟต์
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleCraftingUI(!uiCraftActive);
        }

        // ตรวจสอบว่าผู้เล่นหันขึ้นหรือลง
        if (verticalInput > 0 && !isFacingUp)
        {
            FlipDirection();
        }
        else if (verticalInput < 0 && isFacingUp)
        {
            FlipDirection();
        }

        // อัปเดตตำแหน่งไฟฉายให้ตามหน้าผู้เล่น
        UpdateFlashlightPosition();
    }

    private void FixedUpdate()
    {
        // เคลื่อนที่ Player
        rb.velocity = movement * moveSpeed;
    }

    private void ToggleFlashlight()
    {
        // เปลี่ยนสถานะเปิด/ปิดของไฟฉาย
        isFlashlightOn = !isFlashlightOn;
        if (flashlight != null)
        {
            flashlight.SetActive(isFlashlightOn);
        }
    }

    private void ToggleCraftingUI(bool isActive)
    {
        uiCrafting.SetActive(isActive);
        uiCraftActive = isActive;
    }

    private void FlipDirection()
    {
        // สลับการหันหน้าของ Player ขึ้นหรือลง
        isFacingUp = !isFacingUp;

        if (flashlight != null)
        {
            flashlight.transform.rotation = Quaternion.Euler(0, 0, isFacingUp ? 0 : 180);
        }
    }

    private void UpdateFlashlightPosition()
    {
        if (flashlight != null)
        {
            // กำหนดตำแหน่งของไฟฉายให้อยู่ข้างหน้าผู้เล่นตามทิศทางที่หันขึ้นหรือลง
            Vector3 flashlightPosition = transform.position;
            flashlightPosition.y += isFacingUp ? flashlightDistance : -flashlightDistance;
            flashlight.transform.position = flashlightPosition;
        }
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
            inventory.AddItem(item);
            Destroy(item.gameObject);
        }
    }
}
