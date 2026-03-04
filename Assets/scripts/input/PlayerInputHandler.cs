using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public static PlayerInputHandler Instance {get; private set; }
    void Awake()
    {
        controls = new PlayerInput();

        if(Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_CONTROLS_ON, OnEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_CONTROLS_OFF, OnDisable);
        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_MOUSE_VISIBLE, mouseOn);
        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_MOUSE_INVISIBLE, mouseOff);
    }

    private PlayerInput controls;
    public Vector2 moveInput {get; private set; }
    public Vector2 mousePosition {get; private set; }
    public bool leftClick {get; private set; }
    public bool sprinting {get; private set; }
    public bool backpack {get; private set; }
    public bool stats {get; private set; }

    void OnEnable()
    {
        controls.Enable();

        controls.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.MouseLocation.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();

        controls.Player.LeftClick.performed += ctx => leftClick = true;
        controls.Player.LeftClick.canceled += ctx => leftClick = false;

        controls.Player.Sprint.performed += ctx => sprinting = true;
        controls.Player.Sprint.canceled += ctx => sprinting = false;

        controls.Player.Backpack.performed += ctx => backpack = true;
        controls.Player.Backpack.canceled += ctx => backpack = false;

        controls.Player.Stats.performed += ctx => stats = true;
        controls.Player.Stats.canceled += ctx => stats = false;
        
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void controlsOn()
    {
        
    }

    void controlsOff()
    {
        
    }

    void mouseOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void mouseOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}