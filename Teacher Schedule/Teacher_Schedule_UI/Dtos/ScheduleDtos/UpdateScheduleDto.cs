namespace Teacher_Schedule_UI.Dtos.ScheduleDtos
{
    public class UpdateScheduleDto
    {
        public int ScheduleID { get; set; }
        public int TeacherID { get; set; }
        public int LessonID { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
