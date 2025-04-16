using UnityEngine;
using TMPro;

public class TextInputController : MonoBehaviour
{
    public TMP_InputField inputField;
    public Rigidbody2D playerRb;
    public float jumpForce = 10f;

    void Start()
    {
        inputField.onSubmit.AddListener(HandleInput);
        inputField.ActivateInputField(); // This makes the input auto-focused at start
    }

    void HandleInput(string input)
    {
        input = input.ToLower().Trim();

        if (input == "jump")
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }

        inputField.text = ""; // clear input
        inputField.ActivateInputField(); // keeps it active after submitting
    }
}
