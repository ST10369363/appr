using System.ComponentModel.DataAnnotations;
using System;

namespace appr.Models // Ensure this matches your project's model namespace
{
    public class Donation
    {
        // Matches DonationID INT IDENTITY(1,1) PRIMARY KEY
        public int DonationID { get; set; }

        // Matches DonationType VARCHAR(20) NOT NULL
        [Required(ErrorMessage = "Donation type is required.")]
        [StringLength(20)]
        public string DonationType { get; set; } = string.Empty;

        // Matches ItemDescription TEXT NOT NULL
        [Required(ErrorMessage = "A description of the items is required.")]
        public string ItemDescription { get; set; } = string.Empty;

        // Matches DonationDate DATETIME DEFAULT GETDATE()
        public DateTime DonationDate { get; set; } = DateTime.Now;

        // Matches DeliveryCategory VARCHAR(50) NULL
        [StringLength(50)]
        public string? DeliveryCategory { get; set; }

        // Matches DeliveryAddress VARCHAR(255) NULL
        [StringLength(255)]
        public string? DeliveryAddress { get; set; }

        // Matches NeedsBoxes BIT NULL (Use nullable bool for BIT)
        public bool? NeedsBoxes { get; set; }

        // Matches IsAnonymous BIT NULL
        public bool? IsAnonymous { get; set; }

        // Matches OnSiteLocation VARCHAR(255) NULL
        [StringLength(255)]
        public string? OnSiteLocation { get; set; }

        // Matches UserID INT NULL (Placeholder for a logged-in user ID)
        public int? UserID { get; set; }
    }
}