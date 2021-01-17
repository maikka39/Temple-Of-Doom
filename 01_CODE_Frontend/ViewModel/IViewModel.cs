namespace CODE_Frontend.ViewModel
{
    public interface IViewModel
    {
        /// <summary>
        /// X location of the connection
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y location of the connection
        /// </summary>
        public int Y { get; }


        /// <summary>
        /// Gets the ConsoleText of the view
        /// </summary>
        public ConsoleText View { get; }
    }
}
