// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""8b46f848-fb19-46db-960b-b500940b73db"",
            ""actions"": [
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""a8034e19-92df-443d-8f04-06da252b6cfd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Moving"",
                    ""type"": ""Value"",
                    ""id"": ""2d0d13fb-f922-4ef3-accb-ebbf1c8c52d3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Auto"",
                    ""type"": ""Button"",
                    ""id"": ""ff677527-0b0f-4dec-a35c-05a07449b255"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ab1"",
                    ""type"": ""Button"",
                    ""id"": ""136103a4-b03b-4f05-9472-3df10b96fcad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ab2"",
                    ""type"": ""Button"",
                    ""id"": ""34b5e90d-3a01-4beb-9a43-cdfefb43edb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ab3"",
                    ""type"": ""Button"",
                    ""id"": ""7bc1177d-7d6b-4bad-a48c-a3f0296c93fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fb1x"",
                    ""type"": ""Button"",
                    ""id"": ""6254a14d-5862-4cf2-9f1a-426bc95cbec9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fb2sq"",
                    ""type"": ""Button"",
                    ""id"": ""6439bc95-363c-4044-92c5-f5c9166f6131"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fb3ci"",
                    ""type"": ""Button"",
                    ""id"": ""cc16c937-2410-4dec-9d8a-ffbcc216d355"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fb4tr"",
                    ""type"": ""Button"",
                    ""id"": ""65acd05b-b4e7-48f5-969a-955501dac6be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPup"",
                    ""type"": ""Button"",
                    ""id"": ""afc065a3-d5a4-4237-8288-1f48d1e140b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPleft"",
                    ""type"": ""Button"",
                    ""id"": ""3e38ec66-da45-4c23-a441-cf38a2e85d87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPright"",
                    ""type"": ""Button"",
                    ""id"": ""5d1ffda1-a4e2-415f-af0e-729a99419ad1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DPdown"",
                    ""type"": ""Button"",
                    ""id"": ""b91a4c1f-792f-4d70-bc4b-30feb54c3e4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""04f47748-a12b-465e-a6b2-25994356e884"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83e1aebd-3096-4eb7-a39e-f358e07ceda6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3a888ed-4a6b-456a-834b-912db58043ce"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c95fecf7-a907-483b-a3aa-9dac474c8b66"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Auto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbd4289f-fa75-41de-9890-e0da501fb0f7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ab1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84414334-cd03-4e4a-ba2d-eaaacdafa63d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ab2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ab5be41-bf47-4369-ad0a-b5b2121ac906"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ab3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c4e9359-1a0a-45aa-bd6e-758602445962"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fb1x"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f897211d-462f-43bb-bb90-fc17265e71fd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fb2sq"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98e5b3d0-82c1-4312-a640-5114efc8ea2e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fb3ci"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df36b27d-5a4a-43f8-8721-162687acf7e1"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fb4tr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""081b3cb8-5bb9-497b-8ed7-dace468db670"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2236161c-f089-42fe-a271-f45912369ce7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPleft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d802c068-575b-412c-a1d3-d2d950bc09ed"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPright"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b4f3215-702f-4393-9586-941319350bd3"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPdown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f981ab76-cc1b-4232-80d9-db5bf9ff9cf1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Aiming = m_Gameplay.FindAction("Aiming", throwIfNotFound: true);
        m_Gameplay_Moving = m_Gameplay.FindAction("Moving", throwIfNotFound: true);
        m_Gameplay_Auto = m_Gameplay.FindAction("Auto", throwIfNotFound: true);
        m_Gameplay_Ab1 = m_Gameplay.FindAction("Ab1", throwIfNotFound: true);
        m_Gameplay_Ab2 = m_Gameplay.FindAction("Ab2", throwIfNotFound: true);
        m_Gameplay_Ab3 = m_Gameplay.FindAction("Ab3", throwIfNotFound: true);
        m_Gameplay_fb1x = m_Gameplay.FindAction("fb1x", throwIfNotFound: true);
        m_Gameplay_fb2sq = m_Gameplay.FindAction("fb2sq", throwIfNotFound: true);
        m_Gameplay_fb3ci = m_Gameplay.FindAction("fb3ci", throwIfNotFound: true);
        m_Gameplay_fb4tr = m_Gameplay.FindAction("fb4tr", throwIfNotFound: true);
        m_Gameplay_DPup = m_Gameplay.FindAction("DPup", throwIfNotFound: true);
        m_Gameplay_DPleft = m_Gameplay.FindAction("DPleft", throwIfNotFound: true);
        m_Gameplay_DPright = m_Gameplay.FindAction("DPright", throwIfNotFound: true);
        m_Gameplay_DPdown = m_Gameplay.FindAction("DPdown", throwIfNotFound: true);
        m_Gameplay_Start = m_Gameplay.FindAction("Start", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Aiming;
    private readonly InputAction m_Gameplay_Moving;
    private readonly InputAction m_Gameplay_Auto;
    private readonly InputAction m_Gameplay_Ab1;
    private readonly InputAction m_Gameplay_Ab2;
    private readonly InputAction m_Gameplay_Ab3;
    private readonly InputAction m_Gameplay_fb1x;
    private readonly InputAction m_Gameplay_fb2sq;
    private readonly InputAction m_Gameplay_fb3ci;
    private readonly InputAction m_Gameplay_fb4tr;
    private readonly InputAction m_Gameplay_DPup;
    private readonly InputAction m_Gameplay_DPleft;
    private readonly InputAction m_Gameplay_DPright;
    private readonly InputAction m_Gameplay_DPdown;
    private readonly InputAction m_Gameplay_Start;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aiming => m_Wrapper.m_Gameplay_Aiming;
        public InputAction @Moving => m_Wrapper.m_Gameplay_Moving;
        public InputAction @Auto => m_Wrapper.m_Gameplay_Auto;
        public InputAction @Ab1 => m_Wrapper.m_Gameplay_Ab1;
        public InputAction @Ab2 => m_Wrapper.m_Gameplay_Ab2;
        public InputAction @Ab3 => m_Wrapper.m_Gameplay_Ab3;
        public InputAction @fb1x => m_Wrapper.m_Gameplay_fb1x;
        public InputAction @fb2sq => m_Wrapper.m_Gameplay_fb2sq;
        public InputAction @fb3ci => m_Wrapper.m_Gameplay_fb3ci;
        public InputAction @fb4tr => m_Wrapper.m_Gameplay_fb4tr;
        public InputAction @DPup => m_Wrapper.m_Gameplay_DPup;
        public InputAction @DPleft => m_Wrapper.m_Gameplay_DPleft;
        public InputAction @DPright => m_Wrapper.m_Gameplay_DPright;
        public InputAction @DPdown => m_Wrapper.m_Gameplay_DPdown;
        public InputAction @Start => m_Wrapper.m_Gameplay_Start;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Aiming.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAiming;
                @Moving.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoving;
                @Auto.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAuto;
                @Auto.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAuto;
                @Auto.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAuto;
                @Ab1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb1;
                @Ab1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb1;
                @Ab1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb1;
                @Ab2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb2;
                @Ab2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb2;
                @Ab2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb2;
                @Ab3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb3;
                @Ab3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb3;
                @Ab3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAb3;
                @fb1x.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb1x;
                @fb1x.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb1x;
                @fb1x.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb1x;
                @fb2sq.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb2sq;
                @fb2sq.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb2sq;
                @fb2sq.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb2sq;
                @fb3ci.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb3ci;
                @fb3ci.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb3ci;
                @fb3ci.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb3ci;
                @fb4tr.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb4tr;
                @fb4tr.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb4tr;
                @fb4tr.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFb4tr;
                @DPup.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPup;
                @DPup.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPup;
                @DPup.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPup;
                @DPleft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPleft;
                @DPleft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPleft;
                @DPleft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPleft;
                @DPright.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPright;
                @DPright.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPright;
                @DPright.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPright;
                @DPdown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPdown;
                @DPdown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPdown;
                @DPdown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPdown;
                @Start.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
                @Auto.started += instance.OnAuto;
                @Auto.performed += instance.OnAuto;
                @Auto.canceled += instance.OnAuto;
                @Ab1.started += instance.OnAb1;
                @Ab1.performed += instance.OnAb1;
                @Ab1.canceled += instance.OnAb1;
                @Ab2.started += instance.OnAb2;
                @Ab2.performed += instance.OnAb2;
                @Ab2.canceled += instance.OnAb2;
                @Ab3.started += instance.OnAb3;
                @Ab3.performed += instance.OnAb3;
                @Ab3.canceled += instance.OnAb3;
                @fb1x.started += instance.OnFb1x;
                @fb1x.performed += instance.OnFb1x;
                @fb1x.canceled += instance.OnFb1x;
                @fb2sq.started += instance.OnFb2sq;
                @fb2sq.performed += instance.OnFb2sq;
                @fb2sq.canceled += instance.OnFb2sq;
                @fb3ci.started += instance.OnFb3ci;
                @fb3ci.performed += instance.OnFb3ci;
                @fb3ci.canceled += instance.OnFb3ci;
                @fb4tr.started += instance.OnFb4tr;
                @fb4tr.performed += instance.OnFb4tr;
                @fb4tr.canceled += instance.OnFb4tr;
                @DPup.started += instance.OnDPup;
                @DPup.performed += instance.OnDPup;
                @DPup.canceled += instance.OnDPup;
                @DPleft.started += instance.OnDPleft;
                @DPleft.performed += instance.OnDPleft;
                @DPleft.canceled += instance.OnDPleft;
                @DPright.started += instance.OnDPright;
                @DPright.performed += instance.OnDPright;
                @DPright.canceled += instance.OnDPright;
                @DPdown.started += instance.OnDPdown;
                @DPdown.performed += instance.OnDPdown;
                @DPdown.canceled += instance.OnDPdown;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnAiming(InputAction.CallbackContext context);
        void OnMoving(InputAction.CallbackContext context);
        void OnAuto(InputAction.CallbackContext context);
        void OnAb1(InputAction.CallbackContext context);
        void OnAb2(InputAction.CallbackContext context);
        void OnAb3(InputAction.CallbackContext context);
        void OnFb1x(InputAction.CallbackContext context);
        void OnFb2sq(InputAction.CallbackContext context);
        void OnFb3ci(InputAction.CallbackContext context);
        void OnFb4tr(InputAction.CallbackContext context);
        void OnDPup(InputAction.CallbackContext context);
        void OnDPleft(InputAction.CallbackContext context);
        void OnDPright(InputAction.CallbackContext context);
        void OnDPdown(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
}
