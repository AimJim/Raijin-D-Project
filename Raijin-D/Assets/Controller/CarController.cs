// GENERATED AUTOMATICALLY FROM 'Assets/Controller/CarController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CarControllerAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CarControllerAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CarController"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""b89e0ccc-a5a3-4582-b771-bd149b397a20"",
            ""actions"": [
                {
                    ""name"": ""Acceleration"",
                    ""type"": ""Value"",
                    ""id"": ""74d25e38-0d88-4914-a0d8-aea9b6eda94e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake&Backwards"",
                    ""type"": ""Value"",
                    ""id"": ""c75c2ad3-d0ca-4884-9644-277e29d57cde"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""ad8ad12e-778b-4434-82b4-19e93c92c152"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Nitro"",
                    ""type"": ""Button"",
                    ""id"": ""1816bb84-38c3-4887-bd1e-a977b61ec92e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeSize"",
                    ""type"": ""Button"",
                    ""id"": ""46e87108-ae46-4e82-b498-a529790fad2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandBrake"",
                    ""type"": ""Button"",
                    ""id"": ""fab4305c-fb26-4178-a7e2-6484dd693fae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""856dba45-aa80-48ab-8770-9c35a00ff219"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62c42f60-bb19-4e90-a7df-13a941908af4"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0cae490-f040-4a34-b42d-3ee0877c4d9f"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake&Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d2d0596-6706-42ac-b5c5-1e8ec4931ba0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake&Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e60fe98-eb4f-4784-8746-835d40473aff"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Teclas"",
                    ""id"": ""cb5b9127-74ef-4e0b-8668-6a8177c75965"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ea6dc02a-a377-4f9f-a434-3093eaab5422"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""59c9f9c3-381a-4408-8eb1-2f690024489e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9695bbba-9012-4857-a16a-da65b6c81a79"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""324facf7-ad14-479b-a503-0c36307f93e4"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f994781d-af6a-4357-8dd4-65b8fd423d9f"",
                    ""path"": ""<Keyboard>/#(P)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nitro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4287f7f-820b-49bc-820a-8f47da5fcee0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nitro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""586a961b-477e-4ba2-a2c0-edd5f0383e5e"",
                    ""path"": ""<Keyboard>/#(O)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSize"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b987b9dd-10f2-4d06-ad43-3ceb9539cb3a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSize"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5af02c7e-b160-46cd-a022-eb01593c786c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cff9d1a-659f-4259-94c8-bfddca80a445"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Acceleration = m_Car.FindAction("Acceleration", throwIfNotFound: true);
        m_Car_BrakeBackwards = m_Car.FindAction("Brake&Backwards", throwIfNotFound: true);
        m_Car_Steer = m_Car.FindAction("Steer", throwIfNotFound: true);
        m_Car_Nitro = m_Car.FindAction("Nitro", throwIfNotFound: true);
        m_Car_ChangeSize = m_Car.FindAction("ChangeSize", throwIfNotFound: true);
        m_Car_HandBrake = m_Car.FindAction("HandBrake", throwIfNotFound: true);
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

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Acceleration;
    private readonly InputAction m_Car_BrakeBackwards;
    private readonly InputAction m_Car_Steer;
    private readonly InputAction m_Car_Nitro;
    private readonly InputAction m_Car_ChangeSize;
    private readonly InputAction m_Car_HandBrake;
    public struct CarActions
    {
        private @CarControllerAsset m_Wrapper;
        public CarActions(@CarControllerAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Acceleration => m_Wrapper.m_Car_Acceleration;
        public InputAction @BrakeBackwards => m_Wrapper.m_Car_BrakeBackwards;
        public InputAction @Steer => m_Wrapper.m_Car_Steer;
        public InputAction @Nitro => m_Wrapper.m_Car_Nitro;
        public InputAction @ChangeSize => m_Wrapper.m_Car_ChangeSize;
        public InputAction @HandBrake => m_Wrapper.m_Car_HandBrake;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Acceleration.started -= m_Wrapper.m_CarActionsCallbackInterface.OnAcceleration;
                @Acceleration.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnAcceleration;
                @Acceleration.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnAcceleration;
                @BrakeBackwards.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakeBackwards;
                @BrakeBackwards.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakeBackwards;
                @BrakeBackwards.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakeBackwards;
                @Steer.started -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Nitro.started -= m_Wrapper.m_CarActionsCallbackInterface.OnNitro;
                @Nitro.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnNitro;
                @Nitro.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnNitro;
                @ChangeSize.started -= m_Wrapper.m_CarActionsCallbackInterface.OnChangeSize;
                @ChangeSize.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnChangeSize;
                @ChangeSize.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnChangeSize;
                @HandBrake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnHandBrake;
                @HandBrake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnHandBrake;
                @HandBrake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnHandBrake;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Acceleration.started += instance.OnAcceleration;
                @Acceleration.performed += instance.OnAcceleration;
                @Acceleration.canceled += instance.OnAcceleration;
                @BrakeBackwards.started += instance.OnBrakeBackwards;
                @BrakeBackwards.performed += instance.OnBrakeBackwards;
                @BrakeBackwards.canceled += instance.OnBrakeBackwards;
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @Nitro.started += instance.OnNitro;
                @Nitro.performed += instance.OnNitro;
                @Nitro.canceled += instance.OnNitro;
                @ChangeSize.started += instance.OnChangeSize;
                @ChangeSize.performed += instance.OnChangeSize;
                @ChangeSize.canceled += instance.OnChangeSize;
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    public interface ICarActions
    {
        void OnAcceleration(InputAction.CallbackContext context);
        void OnBrakeBackwards(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
        void OnNitro(InputAction.CallbackContext context);
        void OnChangeSize(InputAction.CallbackContext context);
        void OnHandBrake(InputAction.CallbackContext context);
    }
}
