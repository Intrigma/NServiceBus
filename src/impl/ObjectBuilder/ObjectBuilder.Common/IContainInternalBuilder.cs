namespace NServiceBus.ObjectBuilder.Common
{
    /// <summary>
    /// Interface that asserts that implementers contain an instance of IBuilderInternal.
    /// </summary>
    public interface IContainInternalBuilder
    {
        /// <summary>
        /// The builder to which calls will be dispatched.
        /// </summary>
        IBuilderInternal Builder { get; set; }
    }
}
