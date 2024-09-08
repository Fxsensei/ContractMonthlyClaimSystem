// Models/Claim.cs
namespace GuiApplication.Models
{
    public class Claim
    {
        public int Id { get; set; }  // Unique identifier for the claim
        public string LecturerName { get; set; }  // Name of the lecturer submitting the claim
        public double HoursWorked { get; set; }  // Number of hours worked
        public double HourlyRate { get; set; }  // Pay rate per hour
        public string Notes { get; set; }  // Additional notes or descriptions
        public string DocumentPath { get; set; }  // File path to supporting documents
        public string Status { get; set; } = "Pending";  // Status of the claim, default is "Pending"
    }
}
