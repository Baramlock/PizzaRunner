// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InputSystem/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

#pragma warning disable SA1649 // File name should match first type name
public class @PlayerInput : IInputActionCollection, IDisposable
#pragma warning restore SA1649 // File name should match first type name
{
#pragma warning disable IDE1006 // Стили именования
#pragma warning disable SA1300 // Element should begin with upper-case letter
    public InputActionAsset asset { get; }
#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore IDE1006 // Стили именования
#pragma warning disable SA1201 // Elements should appear in the correct order
    public @PlayerInput()
#pragma warning restore SA1201 // Elements should appear in the correct order
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""009bc0f5-6cc3-4082-9aad-e783bbbfa356"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""19db43f3-da26-43fc-9521-29bc511ce60c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""44ce275f-ce59-48a2-9dc5-ed0e29c03763"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""416e55e9-345a-488e-ab13-7c61ffb358eb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f5099bf0-0f57-4c07-85fd-53a649f50597"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
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
#pragma warning disable SA1028 // Code should not contain trailing whitespace
        
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
// Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

#pragma warning disable SA1201 // Elements should appear in the correct order
    public InputBinding? bindingMask
#pragma warning restore SA1201 // Elements should appear in the correct order
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

    // Player
#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1308 // Variable names should not be prefixed
    private readonly InputActionMap m_Player;
#pragma warning restore SA1308 // Variable names should not be prefixed
#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning disable SA1308 // Variable names should not be prefixed
    private IPlayerActions m_PlayerActionsCallbackInterface;
#pragma warning restore SA1308 // Variable names should not be prefixed
#pragma warning disable SA1308 // Variable names should not be prefixed
#pragma warning disable SA1214 // Readonly fields should appear before non-readonly fields
    private readonly InputAction m_Player_Move;
#pragma warning restore SA1214 // Readonly fields should appear before non-readonly fields
#pragma warning restore SA1308 // Variable names should not be prefixed
    public struct PlayerActions
    {
#pragma warning disable IDE0044 // Добавить модификатор только для чтения
#pragma warning disable SA1308 // Variable names should not be prefixed
        private @PlayerInput m_Wrapper;
#pragma warning restore SA1308 // Variable names should not be prefixed
#pragma warning restore IDE0044 // Добавить модификатор только для чтения
#pragma warning disable SA1502 // Element should not be on a single line
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
#pragma warning restore SA1502 // Element should not be on a single line
        public InputAction @Move => m_Wrapper.m_Player_Move;
#pragma warning disable SA1502 // Element should not be on a single line
        public InputActionMap Get() { return m_Wrapper.m_Player; }
#pragma warning restore SA1502 // Element should not be on a single line
#pragma warning disable SA1502 // Element should not be on a single line
        public void Enable() { Get().Enable(); }
#pragma warning restore SA1502 // Element should not be on a single line
#pragma warning disable SA1502 // Element should not be on a single line
        public void Disable() { Get().Disable(); }
#pragma warning restore SA1502 // Element should not be on a single line
#pragma warning disable IDE1006 // Стили именования
#pragma warning disable SA1300 // Element should begin with upper-case letter
#pragma warning disable SA1201 // Elements should appear in the correct order
        public bool enabled => Get().enabled;
#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore IDE1006 // Стили именования
#pragma warning disable SA1502 // Element should not be on a single line
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
#pragma warning restore SA1502 // Element should not be on a single line
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
#pragma warning disable SA1513 // Closing brace should be followed by blank line
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
#pragma warning restore SA1513 // Closing brace should be followed by blank line
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
#pragma warning disable SA1201 // Elements should appear in the correct order
    public PlayerActions @Player => new PlayerActions(this);
#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning disable SA1308 // Variable names should not be prefixed
#pragma warning disable SA1201 // Elements should appear in the correct order
    private int m_MouseandKeyboardSchemeIndex = -1;
#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1308 // Variable names should not be prefixed
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1)
            {
                m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            }

            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
#pragma warning disable SA1201 // Elements should appear in the correct order
    public interface IPlayerActions
#pragma warning restore SA1201 // Elements should appear in the correct order
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
