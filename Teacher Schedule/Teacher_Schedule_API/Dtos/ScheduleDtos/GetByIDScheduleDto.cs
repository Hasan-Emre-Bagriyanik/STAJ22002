namespace Teacher_Schedule_Api.Dtos.ScheduleDtos
{
    public class GetByIDScheduleDto
    {
        public int ScheduleID { get; set; }
        public int TeacherID { get; set; }
        public int LessonID { get; set; }
        public string DayOfWeek { get; set; }
        public string TeacherName { get; set; }
        public string LessonName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
