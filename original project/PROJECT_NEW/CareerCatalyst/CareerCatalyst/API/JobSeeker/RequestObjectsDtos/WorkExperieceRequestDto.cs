﻿namespace CareerCatalyst.API.JobSeeker.RequestObjectsDtos
{
    public class WorkExperieceRequestDto
    {
        public string JobTitle { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public DateTime ServiceStart { get; set; }

        public DateTime ServiceEnd { get; set; }


    }
}
