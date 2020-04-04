using System.Threading;

namespace IDK {

    /// <summary>
    /// Class to perform background tasks
    /// </summary>
    abstract class Task {

        // worker thread on which the task is running
        private Thread Worker;

        // flag indicating whether the task is running or not
        private volatile bool Running;

        // flag indicating whether the task is paused or not
        private volatile bool Paused = false;

        // task update interval
        public int Interval { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Task(int interval) {
            Worker = new Thread(new ThreadStart(Execute));
            Interval = interval;
        }

        /// <summary>
        /// Pauses the updating of the task
        /// </summary>
        public virtual void Pause() {
            Paused = true;
        }

        /// <summary>
        /// Resumes the updating of the task
        /// </summary>
        public virtual void Resume() {
            Paused = false;
        }

        /// <summary>
        /// Starts the task
        /// </summary>
        public virtual void Start() {
            Running = true;
            Worker.Start();
        }

        /// <summary>
        /// Stops the task
        /// </summary>
        public virtual void Stop() {
            Running = false;

            try {
                Worker.Interrupt();
            } catch { }
        }

        /// <summary>
        /// Ensures that the calling thread waits for the worker thread to complete
        /// </summary>
        public void WaitForWorkerToComplete() {
            Worker.Join();
        }
        
        /// <summary>
        /// Method that gets called when the task executes. Performs the background task
        /// </summary>
        private void Execute() {
            Initialize();

            while (Running) {
                if (!Paused) {
                    Update();
                }

                try {
                    Thread.Sleep(Interval);
                } catch { }
            }
        }

        /// <summary>
        /// Method that gets called before the task starts executing to perform necessary initialization
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Method that gets called when the task updates
        /// </summary>
        public abstract void Update();
    }
}
