using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerLookAround))]
public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.OnFootActions onFoot;
    PlayerMotor playerMotor;
    PlayerInteract playerInteract;
    PlayerLookAround playerLookAround;
    WeaponManager weaponManager;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerMotor = GetComponent<PlayerMotor>();
        playerInteract = GetComponent<PlayerInteract>();
        playerLookAround = GetComponent<PlayerLookAround>();
        weaponManager = GetComponent<WeaponManager>();

        onFoot.Jump.performed += _ => playerMotor.HandleJump();
        onFoot.Dash.performed += _ => playerMotor.HandleDash();

        onFoot.Interact.performed += _ => playerInteract.HandleInteract();

        onFoot.Sprint.started += _ => playerMotor.HandleStartSprint();
        onFoot.Sprint.canceled += _ => playerMotor.HandleStopSprint();

        onFoot.Shoot.started += _ => weaponManager.HandleShoot();
        onFoot.Shoot.canceled += _ => weaponManager.HandleStopShoot();

        onFoot.Relaod.performed += _ => weaponManager.HandleReload();

        onFoot.ChangeWeapon.performed += _ => weaponManager.SwitchWeapon(); 
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMotor.HandleMove(onFoot.Movement.ReadValue<Vector2>());
        playerMotor.HandleGravity();

        playerLookAround.HandleLookAround(onFoot.LookAround.ReadValue<Vector2>());
    }

    void OnEnable()
    {
        onFoot.Enable();
    }

    void OnDisable()
    {
        onFoot.Disable();
    }
}
