namespace Lib.models
{
    /// <summary>
    /// Represents a rating scale with predefined values.
    /// </summary>
    /// <remarks>
    /// The Rating enum defines a scale with values ranging from Poor to Excellent.
    /// </remarks>
    public enum Rating
    {
        /// <summary>
        /// Indicates a poor rating.
        /// </summary>
        Poor = 1,
        /// <summary>
        /// Indicates a fair rating.
        /// </summary>
        Fair,
        /// <summary>
        /// Indicates an average rating.
        /// </summary>
        Average,
        /// <summary>
        /// Indicates a good rating.
        /// </summary>
        Good,
        /// <summary>
        /// Indicates an excellent rating.
        /// </summary>
        Excellent
    }
}
