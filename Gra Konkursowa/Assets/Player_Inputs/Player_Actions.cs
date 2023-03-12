// GENERATED AUTOMATICALLY FROM 'Assets/Player_Inputs/Player_Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Actions"",
    ""maps"": [
        {
            ""name"": ""Movement_Map"",
            ""id"": ""21c9d47b-e000-4ff3-993d-a575d4f50d4b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""52ab0b1b-396c-49c4-b247-0cc2a7dccc41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player_Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""020c77fd-b7cc-4239-9e24-fc7b7dd24284"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f1eb59ec-7342-4f19-a411-77d69b72832c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Movement_Vector"",
                    ""id"": ""7fc45864-e1c1-4b78-ba7b-b2f70ab5b21d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""37e90e8e-ad55-4cf0-9e9b-f32d17085e5d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cb6b5d1c-7338-426c-a98c-a102cf5f6367"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44fe033e-a242-4ee5-b18b-81385b06b1d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d403a604-fc1f-4da5-9fb8-adb9b8da358a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0c08bc24-7d77-4c85-b2b3-74166f72fd71"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bc8b02e-33a9-4fd2-90f4-7a2cc348ce5b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Player_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu_Map"",
            ""id"": ""f54f9bdf-4a44-4043-a66f-80d1b1b037cc"",
            ""actions"": [
                {
                    ""name"": ""Open_Pause_Menu"",
                    ""type"": ""Button"",
                    ""id"": ""e9484613-1888-4ead-9069-f59661aa87e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenConsole"",
                    ""type"": ""Button"",
                    ""id"": ""748a777f-d098-4d6d-a859-78151d58f325"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpArrow"",
                    ""type"": ""Button"",
                    ""id"": ""b845a704-915a-4916-b4cb-5278512786d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownArrow"",
                    ""type"": ""Button"",
                    ""id"": ""0dd18f57-7a9c-4d26-986d-abf4527847ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""5070a6ab-fa1f-4c52-81bd-bbc095d4d447"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d89800ed-d987-4cbe-9b8f-72a9dee9c139"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Open_Pause_Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c759343a-8e22-45cf-b581-8ae6b9f20917"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenConsole"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dc0a8ab-e0be-48eb-8660-140dd190b6e3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2343774-f106-483b-a4f0-516438a80161"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d4bb3b2-a9d8-4671-9cc8-ead73589534b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat_Map"",
            ""id"": ""0c405ff2-6602-4083-bb7d-cec728558da1"",
            ""actions"": [
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""fdb7bd40-ff62-47b3-926d-e1cdd1e68286"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use_Ability_1"",
                    ""type"": ""Button"",
                    ""id"": ""a7d98704-076c-4310-9d58-551e8e473491"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use_Ability_2"",
                    ""type"": ""Button"",
                    ""id"": ""6411a62f-9b91-4fc2-9371-905b1bd6bd15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload_Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""8cf911a0-c48f-4894-ae84-f713cb6a1fb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6cc033eb-f71e-481a-8e2f-3e25ac0b15a9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b37e29d-11b6-4e74-b78b-2bf7bde0eab9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Use_Ability_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8779681f-d49e-4c61-b99d-c0d576ff6afe"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Use_Ability_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8f5efea-6b7f-452d-8e34-08aade84b5d9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Reload_Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Other_Map"",
            ""id"": ""1f75fba5-73fd-4042-ab0c-200569d5b462"",
            ""actions"": [
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""209d4ecd-b9a5-4f27-a91b-155e5a866730"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Free_Camera"",
                    ""type"": ""Button"",
                    ""id"": ""8ec5b542-75af-4f1f-92ca-87fb23cb2ef2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""34842b69-763c-4f3e-a227-385006f99115"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6acbb4ec-e524-4eb0-be7b-ead551166848"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Free_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement_Map
        m_Movement_Map = asset.FindActionMap("Movement_Map", throwIfNotFound: true);
        m_Movement_Map_Movement = m_Movement_Map.FindAction("Movement", throwIfNotFound: true);
        m_Movement_Map_Player_Rotation = m_Movement_Map.FindAction("Player_Rotation", throwIfNotFound: true);
        m_Movement_Map_Dash = m_Movement_Map.FindAction("Dash", throwIfNotFound: true);
        // Menu_Map
        m_Menu_Map = asset.FindActionMap("Menu_Map", throwIfNotFound: true);
        m_Menu_Map_Open_Pause_Menu = m_Menu_Map.FindAction("Open_Pause_Menu", throwIfNotFound: true);
        m_Menu_Map_OpenConsole = m_Menu_Map.FindAction("OpenConsole", throwIfNotFound: true);
        m_Menu_Map_UpArrow = m_Menu_Map.FindAction("UpArrow", throwIfNotFound: true);
        m_Menu_Map_DownArrow = m_Menu_Map.FindAction("DownArrow", throwIfNotFound: true);
        m_Menu_Map_Enter = m_Menu_Map.FindAction("Enter", throwIfNotFound: true);
        // Combat_Map
        m_Combat_Map = asset.FindActionMap("Combat_Map", throwIfNotFound: true);
        m_Combat_Map_Shooting = m_Combat_Map.FindAction("Shooting", throwIfNotFound: true);
        m_Combat_Map_Use_Ability_1 = m_Combat_Map.FindAction("Use_Ability_1", throwIfNotFound: true);
        m_Combat_Map_Use_Ability_2 = m_Combat_Map.FindAction("Use_Ability_2", throwIfNotFound: true);
        m_Combat_Map_Reload_Weapon = m_Combat_Map.FindAction("Reload_Weapon", throwIfNotFound: true);
        // Other_Map
        m_Other_Map = asset.FindActionMap("Other_Map", throwIfNotFound: true);
        m_Other_Map_Interaction = m_Other_Map.FindAction("Interaction", throwIfNotFound: true);
        m_Other_Map_Free_Camera = m_Other_Map.FindAction("Free_Camera", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movement_Map
    private readonly InputActionMap m_Movement_Map;
    private IMovement_MapActions m_Movement_MapActionsCallbackInterface;
    private readonly InputAction m_Movement_Map_Movement;
    private readonly InputAction m_Movement_Map_Player_Rotation;
    private readonly InputAction m_Movement_Map_Dash;
    public struct Movement_MapActions
    {
        private @Player_Actions m_Wrapper;
        public Movement_MapActions(@Player_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Movement_Map_Movement;
        public InputAction @Player_Rotation => m_Wrapper.m_Movement_Map_Player_Rotation;
        public InputAction @Dash => m_Wrapper.m_Movement_Map_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Movement_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Movement_MapActions set) { return set.Get(); }
        public void SetCallbacks(IMovement_MapActions instance)
        {
            if (m_Wrapper.m_Movement_MapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnMovement;
                @Player_Rotation.started -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnPlayer_Rotation;
                @Player_Rotation.performed -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnPlayer_Rotation;
                @Player_Rotation.canceled -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnPlayer_Rotation;
                @Dash.started -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Movement_MapActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_Movement_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Player_Rotation.started += instance.OnPlayer_Rotation;
                @Player_Rotation.performed += instance.OnPlayer_Rotation;
                @Player_Rotation.canceled += instance.OnPlayer_Rotation;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public Movement_MapActions @Movement_Map => new Movement_MapActions(this);

    // Menu_Map
    private readonly InputActionMap m_Menu_Map;
    private IMenu_MapActions m_Menu_MapActionsCallbackInterface;
    private readonly InputAction m_Menu_Map_Open_Pause_Menu;
    private readonly InputAction m_Menu_Map_OpenConsole;
    private readonly InputAction m_Menu_Map_UpArrow;
    private readonly InputAction m_Menu_Map_DownArrow;
    private readonly InputAction m_Menu_Map_Enter;
    public struct Menu_MapActions
    {
        private @Player_Actions m_Wrapper;
        public Menu_MapActions(@Player_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Open_Pause_Menu => m_Wrapper.m_Menu_Map_Open_Pause_Menu;
        public InputAction @OpenConsole => m_Wrapper.m_Menu_Map_OpenConsole;
        public InputAction @UpArrow => m_Wrapper.m_Menu_Map_UpArrow;
        public InputAction @DownArrow => m_Wrapper.m_Menu_Map_DownArrow;
        public InputAction @Enter => m_Wrapper.m_Menu_Map_Enter;
        public InputActionMap Get() { return m_Wrapper.m_Menu_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Menu_MapActions set) { return set.Get(); }
        public void SetCallbacks(IMenu_MapActions instance)
        {
            if (m_Wrapper.m_Menu_MapActionsCallbackInterface != null)
            {
                @Open_Pause_Menu.started -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnOpen_Pause_Menu;
                @Open_Pause_Menu.performed -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnOpen_Pause_Menu;
                @Open_Pause_Menu.canceled -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnOpen_Pause_Menu;
                @OpenConsole.started -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnOpenConsole;
                @OpenConsole.performed -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnOpenConsole;
                @OpenConsole.canceled -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnOpenConsole;
                @UpArrow.started -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnUpArrow;
                @UpArrow.performed -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnUpArrow;
                @UpArrow.canceled -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnUpArrow;
                @DownArrow.started -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnDownArrow;
                @DownArrow.performed -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnDownArrow;
                @DownArrow.canceled -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnDownArrow;
                @Enter.started -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_Menu_MapActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_Menu_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Open_Pause_Menu.started += instance.OnOpen_Pause_Menu;
                @Open_Pause_Menu.performed += instance.OnOpen_Pause_Menu;
                @Open_Pause_Menu.canceled += instance.OnOpen_Pause_Menu;
                @OpenConsole.started += instance.OnOpenConsole;
                @OpenConsole.performed += instance.OnOpenConsole;
                @OpenConsole.canceled += instance.OnOpenConsole;
                @UpArrow.started += instance.OnUpArrow;
                @UpArrow.performed += instance.OnUpArrow;
                @UpArrow.canceled += instance.OnUpArrow;
                @DownArrow.started += instance.OnDownArrow;
                @DownArrow.performed += instance.OnDownArrow;
                @DownArrow.canceled += instance.OnDownArrow;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public Menu_MapActions @Menu_Map => new Menu_MapActions(this);

    // Combat_Map
    private readonly InputActionMap m_Combat_Map;
    private ICombat_MapActions m_Combat_MapActionsCallbackInterface;
    private readonly InputAction m_Combat_Map_Shooting;
    private readonly InputAction m_Combat_Map_Use_Ability_1;
    private readonly InputAction m_Combat_Map_Use_Ability_2;
    private readonly InputAction m_Combat_Map_Reload_Weapon;
    public struct Combat_MapActions
    {
        private @Player_Actions m_Wrapper;
        public Combat_MapActions(@Player_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shooting => m_Wrapper.m_Combat_Map_Shooting;
        public InputAction @Use_Ability_1 => m_Wrapper.m_Combat_Map_Use_Ability_1;
        public InputAction @Use_Ability_2 => m_Wrapper.m_Combat_Map_Use_Ability_2;
        public InputAction @Reload_Weapon => m_Wrapper.m_Combat_Map_Reload_Weapon;
        public InputActionMap Get() { return m_Wrapper.m_Combat_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Combat_MapActions set) { return set.Get(); }
        public void SetCallbacks(ICombat_MapActions instance)
        {
            if (m_Wrapper.m_Combat_MapActionsCallbackInterface != null)
            {
                @Shooting.started -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnShooting;
                @Shooting.performed -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnShooting;
                @Shooting.canceled -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnShooting;
                @Use_Ability_1.started -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnUse_Ability_1;
                @Use_Ability_1.performed -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnUse_Ability_1;
                @Use_Ability_1.canceled -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnUse_Ability_1;
                @Use_Ability_2.started -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnUse_Ability_2;
                @Use_Ability_2.performed -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnUse_Ability_2;
                @Use_Ability_2.canceled -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnUse_Ability_2;
                @Reload_Weapon.started -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnReload_Weapon;
                @Reload_Weapon.performed -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnReload_Weapon;
                @Reload_Weapon.canceled -= m_Wrapper.m_Combat_MapActionsCallbackInterface.OnReload_Weapon;
            }
            m_Wrapper.m_Combat_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shooting.started += instance.OnShooting;
                @Shooting.performed += instance.OnShooting;
                @Shooting.canceled += instance.OnShooting;
                @Use_Ability_1.started += instance.OnUse_Ability_1;
                @Use_Ability_1.performed += instance.OnUse_Ability_1;
                @Use_Ability_1.canceled += instance.OnUse_Ability_1;
                @Use_Ability_2.started += instance.OnUse_Ability_2;
                @Use_Ability_2.performed += instance.OnUse_Ability_2;
                @Use_Ability_2.canceled += instance.OnUse_Ability_2;
                @Reload_Weapon.started += instance.OnReload_Weapon;
                @Reload_Weapon.performed += instance.OnReload_Weapon;
                @Reload_Weapon.canceled += instance.OnReload_Weapon;
            }
        }
    }
    public Combat_MapActions @Combat_Map => new Combat_MapActions(this);

    // Other_Map
    private readonly InputActionMap m_Other_Map;
    private IOther_MapActions m_Other_MapActionsCallbackInterface;
    private readonly InputAction m_Other_Map_Interaction;
    private readonly InputAction m_Other_Map_Free_Camera;
    public struct Other_MapActions
    {
        private @Player_Actions m_Wrapper;
        public Other_MapActions(@Player_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interaction => m_Wrapper.m_Other_Map_Interaction;
        public InputAction @Free_Camera => m_Wrapper.m_Other_Map_Free_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Other_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Other_MapActions set) { return set.Get(); }
        public void SetCallbacks(IOther_MapActions instance)
        {
            if (m_Wrapper.m_Other_MapActionsCallbackInterface != null)
            {
                @Interaction.started -= m_Wrapper.m_Other_MapActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_Other_MapActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_Other_MapActionsCallbackInterface.OnInteraction;
                @Free_Camera.started -= m_Wrapper.m_Other_MapActionsCallbackInterface.OnFree_Camera;
                @Free_Camera.performed -= m_Wrapper.m_Other_MapActionsCallbackInterface.OnFree_Camera;
                @Free_Camera.canceled -= m_Wrapper.m_Other_MapActionsCallbackInterface.OnFree_Camera;
            }
            m_Wrapper.m_Other_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Free_Camera.started += instance.OnFree_Camera;
                @Free_Camera.performed += instance.OnFree_Camera;
                @Free_Camera.canceled += instance.OnFree_Camera;
            }
        }
    }
    public Other_MapActions @Other_Map => new Other_MapActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IMovement_MapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPlayer_Rotation(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IMenu_MapActions
    {
        void OnOpen_Pause_Menu(InputAction.CallbackContext context);
        void OnOpenConsole(InputAction.CallbackContext context);
        void OnUpArrow(InputAction.CallbackContext context);
        void OnDownArrow(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
    public interface ICombat_MapActions
    {
        void OnShooting(InputAction.CallbackContext context);
        void OnUse_Ability_1(InputAction.CallbackContext context);
        void OnUse_Ability_2(InputAction.CallbackContext context);
        void OnReload_Weapon(InputAction.CallbackContext context);
    }
    public interface IOther_MapActions
    {
        void OnInteraction(InputAction.CallbackContext context);
        void OnFree_Camera(InputAction.CallbackContext context);
    }
}
