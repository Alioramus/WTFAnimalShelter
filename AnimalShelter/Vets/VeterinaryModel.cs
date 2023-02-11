using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter;

public class VeterinaryModel : INotifyPropertyChanged
{
    private readonly ShelterContext _context;

    public List<Animal> Animals { get; set; }

    private List<ShelterAction> _veterinaryRequestsToTake;

    public List<ShelterAction> VeterinaryRequestsToTake
    {
        get => _veterinaryRequestsToTake;
        set
        {
            _veterinaryRequestsToTake = value;
            OnPropertyChanged("VeterinaryRequestsToTake");
        }
    }

    private ShelterAction? _selectedOpenRequest;

    public ShelterAction? SelectedOpenRequest
    {
        get => _selectedOpenRequest;
        set
        {
            _selectedOpenRequest = value;
            OnPropertyChanged("SelectedOpenRequest");
        }
    }

    private List<VeterinaryRequest> _requests;

    public List<VeterinaryRequest> Requests
    {
        get => _requests;
        set
        {
            _requests = value;
            OnPropertyChanged("Requests");
        }
    }

    private VeterinaryRequest? _selectedRequest;

    public VeterinaryRequest? SelectedRequest
    {
        get => _selectedRequest;
        set
        {
            _selectedRequest = value;
            OnPropertyChanged("SelectedRequest");
        }
    }

    public VeterinaryModel(ShelterContext context)
    {
        _context = context;
        Animals = context.Animals.ToList();
        VeterinaryRequestsToTake = context.Actions.Where(element =>
            element.Type == ShelterActionType.VetVisit && element.Status == ShelterActionStatus.Requested).ToList();
        Requests = context.VeterinaryRequests.Include(r => r.ShelterAction).Include(r => r.Vet)
            .Where(element => element.Vet.User == App.CurrentUser).ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public void AddRequest()
    {
        var request = new VeterinaryRequest
        {
            Vet = App.CurrentVet,
            Date = DateTime.Now,
            Description = "",
            Reason = "",
            ShelterAction = SelectedOpenRequest
        };
        SelectedOpenRequest.Status = ShelterActionStatus.InProgress;

        _context.Actions.Update(SelectedOpenRequest);
        _context.VeterinaryRequests.Add(request);
        _context.SaveChanges();
        MessageBox.Show("Request taken");

        VeterinaryRequestsToTake = _context.Actions.Where(element =>
            element.Type == ShelterActionType.VetVisit && element.Status == ShelterActionStatus.Requested).ToList();
        Requests = _context.VeterinaryRequests.Where(element => element.Vet.User == App.CurrentUser).ToList();
        SelectedOpenRequest = null;
    }

    public void CloseRequest()
    {
        SelectedRequest.ShelterAction.Status = ShelterActionStatus.Finished;
        _context.Actions.Update(SelectedRequest.ShelterAction);
        _context.VeterinaryRequests.Update(SelectedRequest);
        _context.SaveChanges();
        MessageBox.Show("Request closed");

        VeterinaryRequestsToTake = _context.Actions.Where(element =>
            element.Type == ShelterActionType.VetVisit && element.Status == ShelterActionStatus.Requested).ToList();
        Requests = _context.VeterinaryRequests.Where(element => element.Vet.User == App.CurrentUser).ToList();
        SelectedRequest = null;
    }

    public void EditRequestDetails()
    {
        if (SelectedRequest == null) return;
        var veterinaryRequestWindow = new VeterinaryRequestWindow();
        veterinaryRequestWindow.DataContext = this;
        veterinaryRequestWindow.Show();
    }
}