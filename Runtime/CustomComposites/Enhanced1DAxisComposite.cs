using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Scripting;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif
[Preserve]
[DisplayStringFormat("{left}/{right}")]
[DisplayName("Left/Right Composite")]
public class Enhanced1DAxisComposite : InputBindingComposite<float>
{
    /// <summary>
    /// Binding for the button represents the left (that is, <c>(-1,0)</c>) direction of the vector.
    /// </summary>
    /// <remarks>
    /// This property is automatically assigned by the input system.
    /// </remarks>
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    [InputControl(layout = "Axis")] public int left = 0;

    /// <summary>
    /// Binding for the button that represents the right (that is, <c>(1,0)</c>) direction of the vector.
    /// </summary>
    /// <remarks>
    /// This property is automatically assigned by the input system.
    /// </remarks>
    [InputControl(layout = "Axis")] public int right = 0;

    [Tooltip("If both the positive and negative side are actuated, decides what value to return. 'Neither' (default) means that " +
    "the resulting value is 0. 'Positive' means that 1 will be returned. 'Negative' means that " +
    "-1 will be returned. 'LastPressed' means that 1 or -1 will be returned based on which button was pressed last")]
    public WhichSideWins whichSideWins = WhichSideWins.LastPressed;

    private bool leftPressedLastFrame;
    private bool rightPressedLastFrame;
    private float leftPressTimestamp;
    private float rightPressTimestamp;

    /// <inheritdoc />
    public override float ReadValue(ref InputBindingCompositeContext context)
    {
        bool leftIsPressed = context.ReadValueAsButton(left);
        bool rightIsPressed = context.ReadValueAsButton(right);
        
        if (leftIsPressed && !leftPressedLastFrame) leftPressTimestamp = Time.time;
        if (rightIsPressed && !rightPressedLastFrame) rightPressTimestamp = Time.time;
        
        leftPressedLastFrame = leftIsPressed;
        rightPressedLastFrame = rightIsPressed;
        
        if (leftIsPressed && rightIsPressed)
            switch (whichSideWins)
            {
                case WhichSideWins.Positive:
                    leftIsPressed = false;
                    break;
                case WhichSideWins.Negative:
                    rightIsPressed = false;
                    break;
                case WhichSideWins.Neither:
                    rightIsPressed = false;
                    leftIsPressed = false;
                    break;
                case WhichSideWins.LastPressed:
                    if (leftPressTimestamp > rightPressTimestamp)
                        rightIsPressed = false;
                    else
                        leftIsPressed = false;
                    break;
            }
        
        if (leftIsPressed)
            return -1f;
        else if (rightIsPressed)
            return 1f;
        else
            return 0f;
    }

#if UNITY_EDITOR
    static Enhanced1DAxisComposite() => Initialize();
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Initialize()
    {
        InputSystem.RegisterBindingComposite<Enhanced1DAxisComposite>();
    }

    public enum WhichSideWins
    {
        Positive,
        Negative,
        Neither,
        LastPressed
    }
}