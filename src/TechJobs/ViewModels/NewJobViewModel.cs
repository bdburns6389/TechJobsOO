using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }
        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        
        [Required]
        [Display(Name = "Location")]
        public int Location { get; set; } //How is this working?  Ask Johnathon Saturday.
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Skill")]
        public int CoreCompetency { get; set; }
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        
        [Required]
        [Display(Name = "Position Type")]
        public int PositionType { get; set; }
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();
        //Is it right for the initiators to have the type, or should they be strings?

        

        public NewJobViewModel()
        {
            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view
        }
    }
}
