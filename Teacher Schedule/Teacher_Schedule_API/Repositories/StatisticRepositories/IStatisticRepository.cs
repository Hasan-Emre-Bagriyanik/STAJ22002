namespace Teacher_Schedule_Api.Repositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int LessonCount();
        int TeacherCount();
        int StudentCommentCount();
        int NumberOfProgrammeLessonsOnMonday();
        int NumberOfProgrammeLessonsOnTuesday();
        int NumberOfProgrammeLessonsOnWednesday();
        int NumberOfProgrammeLessonsOnThursday();
        int NumberOfProgrammeLessonsOnFriday();
    }
}
