﻿namespace Teacher_Schedule_Api.Dtos.LessonDtos
{
    public class UpdateLessonDto
    {
        public int LessonID { get; set; }
        public string LessonName { get; set; }
        public string Branch { get; set; }
        public string Image { get; set; }
    }
}
