using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Interactivity;
using System.ComponentModel;
using ReactiveUI;
using System.Reactive;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using LabMileshko8.Models;

namespace LabMileshko8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Scheduled = BuildAllNotesSchedelued();
            InWork = BuildAllNotesInWork();
            Completed = BuildAllNotesCompleted();
            DeleteScheduled = ReactiveCommand.Create<MyTask>((item) =>
            {
                Scheduled.Remove(item);
            });
            DeleteInWork = ReactiveCommand.Create<MyTask>((item) =>
            {
                InWork.Remove(item);
            });
            DeleteCompleted = ReactiveCommand.Create<MyTask>((item) =>
            {
                Completed.Remove(item);
            });
            ButtonAddImage = ReactiveCommand.Create<MyTask, Unit>((item) =>
            {
                OpenImage(item);
                return Unit.Default;
            });


        }
        public ObservableCollection<MyTask> Scheduled { get; set; }

        private ObservableCollection<MyTask> BuildAllNotesSchedelued()
        {
            return new ObservableCollection<MyTask>
            {
                new MyTask("Planned Task1","Task 1"),
                new MyTask("Planned Task2","Task 2"),
                new MyTask("Planned Task3","Task 3"),
            };
        }

        public ObservableCollection<MyTask> InWork { get; set; }

        private ObservableCollection<MyTask> BuildAllNotesInWork()
        {
            return new ObservableCollection<MyTask>
            {
                new MyTask("InWork Task1",""),
                new MyTask("InWork Task2",""),
                new MyTask("InWork Task3",""),
            };
        }

        public ObservableCollection<MyTask> Completed { get; set; }

        private ObservableCollection<MyTask> BuildAllNotesCompleted()
        {
            return new ObservableCollection<MyTask>
            {
                new MyTask("Completed Task1","Task 1"),
                new MyTask("Completed Task2","Task 2"),
                new MyTask("Completed Task3","Task 3"),
                new MyTask("Completed Task4","Task 4"),
                new MyTask("Completed Task5","Task 5"),
            };
        }

        public ReactiveCommand<MyTask, Unit> DeleteScheduled { get; }
        public ReactiveCommand<MyTask, Unit> DeleteInWork { get; }
        public ReactiveCommand<MyTask, Unit> DeleteCompleted { get; }
        public ReactiveCommand<MyTask, Unit> ButtonAddImage { get; }

        private async void OpenImage(MyTask item)
        {
            var taskPathOut = new OpenFileDialog()
            {
                Title = "Choose file",
                Filters = null
            }.ShowAsync(view);

            string[]? path2 = await taskPathOut;
            if (path2 != null)
            {
                item.PathImage = string.Join(@"\", path2);
            }
        }
        public Window? view;
    }
}