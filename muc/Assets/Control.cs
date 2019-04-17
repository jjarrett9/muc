using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Control : MonoBehaviour
{
    #region Public Variables 
    public enum ButtonStates
    {
        Normal,
        Pressed,
        JustReleased
    };
    public ButtonStates BtnState;
  public NavMeshScript NavMeshScript;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        // Start input
        MLInput.Start();

        // Add button callbacks
        MLInput.OnControllerButtonDown += HandleOnButtonDown;
        MLInput.OnControllerButtonUp += HandleOnButtonUp;

        // Initial State of the Control is Normal
        BtnState = ButtonStates.Normal;
    }

    private void OnDestroy()
    {
        // Stop input
        MLInput.Stop();

        // Remove button callbacks
        MLInput.OnControllerButtonDown -= HandleOnButtonDown;
        MLInput.OnControllerButtonUp -= HandleOnButtonUp;
    }

    private void Update()
    {
        if (BtnState == ButtonStates.Pressed)
        {
            NavMeshScript.UpdateDestination();
        }
    }
    #endregion

    #region Event Handlers
    void HandleOnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        // Callback - Button Up
        if (button == MLInputControllerButton.Bumper)
        {
            BtnState = ButtonStates.JustReleased;
        }
    }

    void HandleOnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        // Callback - Button Down
        if (button == MLInputControllerButton.Bumper)
        {
            // Start bumper timer
            BtnState = ButtonStates.Pressed;
        }
    }
    #endregion
}

