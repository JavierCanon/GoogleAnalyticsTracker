namespace IDK {

    /// <summary>
    /// Main class of the program
    /// </summary>
    class Program {

        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">arguments for the program</param>
        public static void Main(string[] args) {
            App.Initialize(args);

            Config config = Config.GetInstance();
            config.LoadSettings();

            Clock clock = new Clock(config.Settings.CLOCK_TIME);
            clock.Start();
        }
    }
}