using System;
using System.ComponentModel;
using System.Threading;
using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;

namespace Progress.ViewModels
{
    public delegate void TaskFinishedHandler();
    public delegate void ErrorHandler(string message);

    public class ProgressViewModel : ViewModel, INotifyPropertyChanged
    {
        public event TaskFinishedHandler TaskFinished;
        public event ErrorHandler CommandFailed;

        public decimal Progress
        {
            get => progress;
            set
            {
                value = Math.Clamp(value,0, 100);
                if (progress != value)
                {
                    // TODO
                    // Set progress to new value, but ensure it is clamped between 0 and 100
                    // Notify the UI that the property changed
                    // If progress has reached 100:
                    //     Stop running
                    //     Set message to "Task finished"
                    //     Invoke TaskFinished event (to display message box)
                    progress = value;
                    NotifyPropertyChanged(nameof(Progress));

                    if (Progress >= 100)
                    {
                        Running = false;
                        Message = "Task finished";
                        TaskFinished?.Invoke();
                    }
                }
            }
        }

        public int Speed
        {
            get => speed;
            set
            {
                if(value >= 0 && value <= 100)
                {
                    speed = value;
                    NotifyPropertyChanged(nameof(Speed));
                }
            }
        }

        public bool Running
        {
            get => running;
            set
            {
                if (running != value)
                {
                    // TODO
                    // Set running to new value
                    // Notify the UI that the property changed
                    running = value;
                    NotifyPropertyChanged(nameof(Running));
                }

            }
        }

        public string Message
        {
            get => message;
            set
            {
                if (message != value)
                {
                    // TODO
                    // Set message to new value
                    // Notify the UI that the property changed
                    message = value;
                    NotifyPropertyChanged(nameof(Message));
                }
            }
        }

        public DelegateCommand StartCommand { get; }
        public DelegateCommand StopCommand { get; }
        public DelegateCommand RandomCommand { get; }
        public DelegateCommand ResetCommand { get; }

        private readonly Random random;
        private decimal progress;
        private int speed;
        private bool running;
        private string message;

        public ProgressViewModel()
        {
            StartCommand = new DelegateCommand(Start);
            StopCommand = new DelegateCommand(Stop);
            RandomCommand = new DelegateCommand(Random);
            ResetCommand = new DelegateCommand(Reset);

            random = new Random();
            progress = 0;
            speed = 10;
            running = false;
            message = null;
        }

        private void Start(object _)
        {
            // TODO
            // Can only successfully start if not already running
            // If valid: Set Running to true, set Message to "Started", and start a new thread to update the progress.
            // If invalid: Display error message by invoking the CommandFailed event (to be displayed in message box)
            if (!running)
            {
                Running = true;
                Message = "Started";
                Thread updateThread = new Thread(UpdateProgress);
                updateThread.Start();
            }
            else
            {
                Message = "Error. The Progress has already started.";
                CommandFailed?.Invoke("Error. The Progress has already started.");
            }
        }

        private void Stop(object _)
        {
            // TODO
            // Set Running to false
            // Set Message to "Stopped"
            Running = false;
            Message = "Stoped";
        }

        private void Random(object _)
        {
            // TODO
            // Set Progress to random number between 0 and 100
            // Set Speed to random number between 0 and 100
            // Set Message to "Randomized"
            Progress = random.Next(0, 100);
            Speed = random.Next(0, 100);
            Message = "Randomized";
        }

        private void Reset(object _)
        {
            // TODO
            // Reset Progress to 0, Speed to 50, Running to false, and Message to null
            Progress = 0;
            Speed = 50;
            Running = false;
            Message = null;
        }

        private void UpdateProgress()
        {
            // TODO: Method to be executed by thread
            // Repeatedly, as long as Running is true:
            //     Calculate the progress delta based on the current speed (delta = amount to add)
            //     Increase Progress by the delta
            //     Sleep the thread for a fraction of a second

            decimal delta = Speed / 10m;


            while (running)
            {
                Progress += delta;
                Thread.Sleep(100);  
            }
        }
    }
}
