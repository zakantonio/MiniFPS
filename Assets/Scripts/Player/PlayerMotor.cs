using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour, IMovable
{
    private Coroutine decreaseCoroutine;
    private Coroutine increaseCoroutine;

    private int _currentSpeedValue;
    int currentSpeed
    {
        get => _currentSpeedValue;
        set
        {
            _currentSpeedValue = value;
        }
    }

    private int _currentStaminaValue;
    int currentStamina
    {
        get => _currentStaminaValue;
        set
        {
            value = Mathf.Clamp(value, 0, StaminaMax);
            _currentStaminaValue = value;

            UiManager.Instance.SetStaminaSlider(value);
        }
    }

    public int StaminaMax => 100;
    public int SpeedNormal => 5;
    public int SpeedSprint => 15;

    Vector3 playerVelocity = Vector3.zero;
    CharacterController controller;
    Vector3 startPosition;

    bool alreadyJumped = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = SpeedNormal;
        currentStamina = StaminaMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleMove(Vector2 input)
    {
        Vector3 moveDirection = new(input.x, 0f, input.y);

        controller.Move(currentSpeed * Time.deltaTime * transform.TransformDirection(moveDirection));
    }

    public void HandleJump(float amout = 3)
    {
        if (controller.isGrounded)
        {
            playerVelocity.y = amout;
        }
        else if (!alreadyJumped)
        {
            playerVelocity.y = amout;
            alreadyJumped = true;
        }
    }

    public void HandleDash()
    {
        controller.Move(transform.TransformDirection(new Vector3(0f, 0f, 2f)));
    }

    public void HandleStartSprint()
    {
        currentSpeed = SpeedSprint;
        decreaseCoroutine = StartCoroutine(DecreaseStamina());


        if (increaseCoroutine != null)
            StopCoroutine(increaseCoroutine);
    }

    public void HandleStopSprint()
    {
        currentSpeed = SpeedNormal;

        if (decreaseCoroutine != null)
            StopCoroutine(decreaseCoroutine);

        increaseCoroutine = StartCoroutine(IncreaseStamina());
    }

    public void HandleGravity()
    {
        playerVelocity.y -= 5 * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);

        // grounded viene ricalcolato dopo il move
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -5;
            alreadyJumped = false;
        }

        CheckY();
    }

    void CheckY()
    {
        if (transform.position.y <= -10f)
        {
            Player.Instance.OnDead();
        }
    }

    IEnumerator DecreaseStamina()
    {
        if (currentStamina <= 0)
        {
            HandleStopSprint();
            yield return null;
        }

        currentStamina--;

        yield return new WaitForSeconds(0.1f);

        decreaseCoroutine = StartCoroutine(DecreaseStamina());
    }
    IEnumerator IncreaseStamina()
    {
        if (currentStamina >= StaminaMax)
        {
            yield return null;
        }

        currentStamina++;

        yield return new WaitForSeconds(1f);

        increaseCoroutine = StartCoroutine(IncreaseStamina());
    }
}
