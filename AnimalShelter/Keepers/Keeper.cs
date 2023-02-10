using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class Keeper
{
    [Key]
    public int KeeperId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Activity> ActivitiesList;

    public override string ToString() => $"{FirstName} {LastName}";

    
    public Keeper(){}

    public void AddActivity(ActivitiesName activitiyName, DateTime startTime, DateTime endtime)
    {
        ActivitiesList.Add(new Activity(activitiyName, startTime, endtime));
    }

    public void RegisterVisit() { }

    public class Activity
    {
        public ActivitiesName ActivitiyName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Activity(ActivitiesName activitiyName, DateTime startTime, DateTime endtime)
        {
            ActivitiyName = activitiyName;
            StartTime = startTime;
            EndTime = endtime;
        }
    }

    public enum ActivitiesName
    {
        Walk,
        Clean,
        PresentForAdoption
    }
}

