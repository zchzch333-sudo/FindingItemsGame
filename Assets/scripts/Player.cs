
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    InputAction leftClick;
    public GameObject target;
    public bool targetFound;
    public TMP_Text Score;
    public int Points = 0;
    public int allFound = 3;
    public GameObject youWin;
    public AudioSource correct;
    public AudioSource wrong;
    public bool isBlocked = false;
    public bool youWrong = false;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item1Image;
    public GameObject item2Image;
    public GameObject item3Image;

    public bool itemChanged = false;
    public SpriteRenderer changeItemRenderer;
    public Sprite changedSprite;
    public GameObject treasureBox;
    void Start()
    {
        leftClick = InputSystem.actions.FindAction("LeftClick");
        youWin.SetActive(false);
    }

    void Update()
    {
        Vector3 mousePosition =
            Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue());

        transform.position = new Vector3(
            mousePosition.x,
            mousePosition.y,
            transform.position.z);

        if (leftClick.WasReleasedThisFrame() && targetFound == true && isBlocked == false)
        {
            Debug.Log("Found!");
            correct.Play();
            Destroy(target);
            if (target == item1)
            {
                item1Image.SetActive(false);
            }

            if (target == item2)
            {
                item2Image.SetActive(false);
            }

            if (target == item3)
            {
                item3Image.SetActive(false);
            }
            targetFound = false;
            Points ++;
            Score.text = "Score: " + Points;
        }
        if (Points >= allFound)
        {
            youWin.SetActive(true);
        }
        if (leftClick.WasReleasedThisFrame() && youWrong == true)
        {
            wrong.Play();
            youWrong = false;
        }
        if (leftClick.WasReleasedThisFrame() && itemChanged == true)
        {
            changeItemRenderer.sprite = changedSprite;
            Points++;
            correct.Play();
            Score.text = "Score: " + Points;
            itemChanged = false;
            treasureBox.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            targetFound = true;
            target = other.gameObject;
        }
        if (other.gameObject.CompareTag("Barrier"))
        {
            isBlocked = true;
        }
        if (other.gameObject.CompareTag("WrongItem"))
        {
            youWrong = true;
        }
        if (other.gameObject.CompareTag("SwitchItem"))
        {
            itemChanged = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            targetFound = false;
        }
        if (other.gameObject.CompareTag("Barrier"))
        {
            isBlocked = false;
        }
        if (other.gameObject.CompareTag("WrongItem"))
        {
            youWrong = false;
        }
        if (other.gameObject.CompareTag("SwitchItem"))
        {
            itemChanged = false;
        }
    }

}
