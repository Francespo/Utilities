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
[DisplayStringFormat("{up}/{left}/{down}/{right}")]
[DisplayName("Up/Down/Left/Right Composite")]
public class EnhancedVector2Composite : InputBindingComposite<Vector2>
{
    /// <summary>
    /// Binding for the button that represents the up (that is, <c>(0,1)</c>) direction of the vector.
    /// </summary>
    /// <remarks>
    /// This property is automatically assigned by the input system.
    /// </remarks>
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    [InputControl(layout = "Axis")] public int up = 0;

    /// <summary>
    /// Binding for the button represents the down (that is, <c>(0,-1)</c>) direction of the vector.
    /// </summary>
    /// <remarks>
    /// This property is automatically assigned by the input system.
    /// </remarks>
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    [InputControl(layout = "Axis")] public int down = 0;

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

    /// <summary>
    /// How to synthesize a <c>Vector2</c> from the values read from <see cref="up"/>, <see cref="down"/>,
    /// <see cref="left"/>, and <see cref="right"/>.
    /// </summary>
    /// <value>Determines how X and Y of the resulting <c>Vector2</c> are formed from input values.</value>
    /// <remarks>
    /// <example>
    /// <code>
    /// var action = new InputAction();
    ///
    /// // DigitalNormalized composite (the default). Turns gamepad left stick into
    /// // control equivalent to the D-Pad.
    /// action.AddCompositeBinding("2DVector(mode=0)")
    ///     .With("up", "&lt;Gamepad&gt;/leftStick/up")
    ///     .With("down", "&lt;Gamepad&gt;/leftStick/down")
    ///     .With("left", "&lt;Gamepad&gt;/leftStick/left")
    ///     .With("right", "&lt;Gamepad&gt;/leftStick/right");
    ///
    /// // Digital composite. Turns gamepad left stick into control equivalent
    /// // to the D-Pad except that diagonals will not be normalized.
    /// action.AddCompositeBinding("2DVector(mode=1)")
    ///     .With("up", "&lt;Gamepad&gt;/leftStick/up")
    ///     .With("down", "&lt;Gamepad&gt;/leftStick/down")
    ///     .With("left", "&lt;Gamepad&gt;/leftStick/left")
    ///     .With("right", "&lt;Gamepad&gt;/leftStick/right");
    ///
    /// // Analog composite. In this case results in setup that behaves exactly
    /// // the same as leftStick already does. But you could use it, for example,
    /// // to swap directions by binding "up" to leftStick/down and "down" to
    /// // leftStick/up.
    /// action.AddCompositeBinding("2DVector(mode=2)")
    ///     .With("up", "&lt;Gamepad&gt;/leftStick/up")
    ///     .With("down", "&lt;Gamepad&gt;/leftStick/down")
    ///     .With("left", "&lt;Gamepad&gt;/leftStick/left")
    ///     .With("right", "&lt;Gamepad&gt;/leftStick/right");
    /// </code>
    /// </example>
    /// </remarks>
    public Mode mode;

    [Tooltip("ONLY WORKS IF MODE IS NOT SET TO ANALOG. If both the positive and negative side are actuated, decides what value to return. 'Neither' (default) means that " +
    "the resulting value is 0. 'Positive' means that 1 will be returned. 'Negative' means that " +
    "-1 will be returned. 'LastPressed' means that 1 or -1 will be returned based on which button was pressed last")]
    public WhichSideWins xAxisWhichSideWins;
    [Tooltip("ONLY WORKS IF MODE IS NOT SET TO ANALOG. If both the positive and negative side are actuated, decides what value to return. 'Neither' (default) means that " +
"the resulting value is 0. 'Positive' means that 1 will be returned. 'Negative' means that " +
"-1 will be returned. 'LastPressed' means that 1 or -1 will be returned based on which button was pressed last")]
    public WhichSideWins yAxisWhichSideWins;

    private bool upPressedLastFrame;
    private bool downPressedLastFrame;
    private bool leftPressedLastFrame;
    private bool rightPressedLastFrame;
    private float upPressTimestamp;
    private float downPressTimestamp;
    private float leftPressTimestamp;
    private float rightPressTimestamp;

    /// <inheritdoc />
    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
        Mode mode = this.mode;

        if (mode == Mode.Analog)
        {
            float upValue = context.ReadValue<float>(up);
            float downValue = context.ReadValue<float>(down);
            float leftValue = context.ReadValue<float>(left);
            float rightValue = context.ReadValue<float>(right);

            return DpadControl.MakeDpadVector(upValue, downValue, leftValue, rightValue);
        }

        bool upIsPressed = context.ReadValueAsButton(up);
        bool downIsPressed = context.ReadValueAsButton(down);
        bool leftIsPressed = context.ReadValueAsButton(left);
        bool rightIsPressed = context.ReadValueAsButton(right);

        if (upIsPressed && !upPressedLastFrame) upPressTimestamp = Time.time;
        if (downIsPressed && !downPressedLastFrame) downPressTimestamp = Time.time;
        if (leftIsPressed && !leftPressedLastFrame) leftPressTimestamp = Time.time;
        if (rightIsPressed && !rightPressedLastFrame) rightPressTimestamp = Time.time;

        upPressedLastFrame = upIsPressed;
        downPressedLastFrame = downIsPressed;
        leftPressedLastFrame = leftIsPressed;
        rightPressedLastFrame = rightIsPressed;

        if (upIsPressed && downIsPressed)
            switch (yAxisWhichSideWins)
            {
                case WhichSideWins.LeftOrUp:
                    downIsPressed = false;
                    break;
                case WhichSideWins.RightOrDown:
                    upIsPressed = false;
                    break;
                case WhichSideWins.Neither:
                    downIsPressed = false;
                    upIsPressed = false;
                    break;
                case WhichSideWins.LastPressed:
                    if (upPressTimestamp > downPressTimestamp)
                        downIsPressed = false;
                    else
                        upIsPressed = false;
                    break;
            }
        if (leftIsPressed && rightIsPressed)
            switch (xAxisWhichSideWins)
            {
                case WhichSideWins.LeftOrUp:
                    rightIsPressed = false;
                    break;
                case WhichSideWins.RightOrDown:
                    leftIsPressed = false;
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

        return DpadControl.MakeDpadVector(upIsPressed, downIsPressed, leftIsPressed, rightIsPressed, mode == Mode.DigitalNormalized);
    }

    /// <inheritdoc />
    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        Vector2 value = ReadValue(ref context);
        return value.magnitude;
    }

#if UNITY_EDITOR
    static EnhancedVector2Composite() => Initialize();
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Initialize()
    {
        InputSystem.RegisterBindingComposite<EnhancedVector2Composite>();
    }

    /// <summary>
    /// Determines how a <c>Vector2</c> is synthesized from part controls.
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// Part controls are treated as analog meaning that the floating-point values read from controls
        /// will come through as is (minus the fact that the down and left direction values are negated).
        /// </summary>
        Analog = 2,

        /// <summary>
        /// Part controls are treated as buttons (on/off) and the resulting vector is normalized. This means
        /// that if, for example, both left and up are pressed, instead of returning a vector (-1,1), a vector
        /// of roughly (-0.7,0.7) (that is, corresponding to <c>new Vector2(-1,1).normalized</c>) is returned instead.
        /// The resulting 2D area is diamond-shaped.
        /// </summary>
        DigitalNormalized = 0,

        /// <summary>
        /// Part controls are treated as buttons (on/off) and the resulting vector is not normalized. This means
        /// that if, for example, both left and up are pressed, the resulting vector is (-1,1) and has a length
        /// greater than 1. The resulting 2D area is box-shaped.
        /// </summary>
        Digital = 1
    }

    public enum WhichSideWins
    {
        LeftOrUp,
        RightOrDown,
        Neither,
        LastPressed
    }
}

