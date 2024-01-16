﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelPlannerService.Models
{
    // PlaceDetails.cs
    public class PlaceDetails
    {
        public PlaceResult Result { get; set; }
    }

    public class PlaceResult
    {
        public string Name { get; set; }
        public string FormattedAddress { get; set; } // Adjusted to FormattedAddress
                                                     // Add other properties as needed
    }

}