using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : PlayerBased
{
    private PlayerInputs _input;
    private Vector2 _tapScreenPosition;
    protected override void Awake(){
        base.Awake();
        _input = new PlayerInputs();
    }
    private void OnEnable(){
        _input.Enable();
        _input.Player.Tap.performed += OnTap;
        _input.Player.TapPosition.performed += OnTapPositionPerformed;
    }
    private void OnDisable(){
        _input.Disable();
        _input.Player.Tap.performed -= OnTap;
        _input.Player.TapPosition.performed += OnTapPositionPerformed;

    }
    private void OnTap(InputAction.CallbackContext value){
        
        player.ID.Events.OnTapPosition?.Invoke(_tapScreenPosition);

    }
    private void OnTapPositionPerformed(InputAction.CallbackContext value){
        _tapScreenPosition = value.ReadValue<Vector2>();
    }
    
}
