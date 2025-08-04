using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float Horizontal { get; private set; } // �r detta safe? Aka ett bra s�tt att g�ra det p�? 
    public float Vertical { get; private set; }
    public bool JumpPressed { get; private set; }
    public float MouseX { get; private set; }


    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        JumpPressed = Input.GetButtonDown("Jump");
        MouseX = Input.GetAxis("Mouse X");
    }
}
