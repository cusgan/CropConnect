﻿using CropConnect.DTO;

namespace CropConnect.Services.Interfaces
{
    public interface IGuideService
    {
        public List<GuideDTO> GetGuides();
        public List<GuideDTO> QueryGuides(string query);
        public GuideDTO? GetGuideById(int id);
        public bool CreateGuide(int authorid, string title, string content, string heading);
        public bool UpdateGuide(int guideid, string title, string content, string heading);
        public void DeleteGuideById(int id);   
    }
}
