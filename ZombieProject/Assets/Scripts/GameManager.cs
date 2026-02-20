using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool gameActive = true;
    
    public GameObject[] zombies;
    public GameObject selectedZombie;
    public Vector3 selectedSize;
    public Vector3 pushForce;
    private InputAction next, prev, jump;
    private int selectedIndex = 0;
    
    public TMP_Text timerText;
    private float timer;
    
    private int points = 0;
    public TMP_Text pointsText;
   

    private void Start()
    {
        Time.timeScale = 1;
        gameActive = true;
        
        next = InputSystem.actions.FindAction("NextZombie");
        prev = InputSystem.actions.FindAction("PrevZombie");
        jump = InputSystem.actions.FindAction("Jump");
        SelectZombie(selectedIndex);
    }

    private void Update()
    {
        if (next.WasPressedThisFrame() && gameActive)
        {
            Debug.Log("Next");
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            SelectZombie(selectedIndex);
        }

        if (prev.WasPressedThisFrame() && gameActive)
        {
            Debug.Log("Prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = zombies.Length - 1;
            SelectZombie(selectedIndex);
        }

        if (jump.WasPressedThisFrame() && gameActive)
        {
            Debug.Log("Jump");
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(pushForce);
            }
        }
        timer += Time.deltaTime;
        timerText.text = "Time: " + (int)timer;
    }
    
    void SelectZombie(int index)
    {
        if (selectedZombie != null)
        {
            selectedZombie.transform.localScale = Vector3.one;
        }
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("Selected: " + selectedZombie);
    }

    public void AddPoints(int amount)
    {
        points += amount;
        pointsText.text = "Points: " + points;
    }
}
