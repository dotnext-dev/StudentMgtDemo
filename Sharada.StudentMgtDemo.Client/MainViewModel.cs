using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharada.StudentMgtDemo.Client
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IStudentsApi _apiClient;

        public MainViewModel()
        {
            _apiClient = RestService.For<IStudentsApi>("http://localhost:56988/");
        }

        private IList<Student> _students;
        private IList<Enrollment> _enrollments;
        private IList<Service> _services;
        private bool _isBusy = false;

        public IList<Student> Students
        {
            get { return _students; }
            set { SetProperty(ref _students, value); }
        }

        public IList<Enrollment> Enrollments
        {
            get { return _enrollments; }
            set { SetProperty(ref _enrollments, value); }
        }

        public IList<Service> Services
        {
            get { return _services; }
            set { SetProperty(ref _services, value); }
        }

        public bool IsNotBusy
        {
            get { return !_isBusy; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set 
            { 
                SetProperty(ref _isBusy, value); 
                OnPropertyChanged(nameof(IsNotBusy)); 
            }
        }

        internal async Task GetStudentsAsync()
        {
            IsBusy = true;
            try
            {
                await Task.Delay(500); //force some delay
                Students = await _apiClient.GetStudents();
                await Task.Delay(500); //force some delay
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal async Task GetEnrollmentsAsync(int studentId)
        {
            IsBusy = true;
            try
            {
                await Task.Delay(500); //force some delay
                Enrollments = await _apiClient.GetEnrollments(studentId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal async Task GetServicesAsync(int studentId)
        {
            IsBusy = true;
            try
            {
                await Task.Delay(500); //force some delay
                Services = await _apiClient.GetServices(studentId);
                await Task.Delay(500); //force some delay
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
