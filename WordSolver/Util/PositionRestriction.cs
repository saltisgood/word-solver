namespace WordSolver.Util
{
    /// <summary>
    /// An enum representation of the restrictions on a letter's position in a word
    /// </summary>
    public enum PositionRestriction
    {
        /// <summary>
        /// No restrictions on the letter's position
        /// </summary>
        NONE = 0, 
        /// <summary>
        /// The letter must be used at the start of the word
        /// </summary>
        START = 1, 
        /// <summary>
        /// The letter must be used at the end of the word
        /// </summary>
        END = 2
    }
}
