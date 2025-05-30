//using AutoLife.Domain.Enums;
//using AutoLife.Domain.Models;

//namespace AutoLife.Data.Repositories;

//public class DummyRepository
//{
//    public static List<UserProfile> GetAllUserProfiles() =>
//    [
//        new UserProfile { Name = "Ludde Andersson", ToDoList = 
//            [
//                new() { Title = "Handla", Category = ToDoCategory.Shopping, Date = DateTime.Now }, 
//                new() { Title = "Städa toa nere", Category = ToDoCategory.Cleaning, Date = DateTime.Now.AddDays(2) },
//                new() { Title = "Dammsug uppe", Category = ToDoCategory.Cleaning, Date = DateTime.Now.AddDays(3) },
//            ] },
//        new UserProfile { Name = "Hanna Andersson", ToDoList = 
//            [
//                new() { Title = "Laga mat", Category = ToDoCategory.Cooking, Date = DateTime.Now }, 
//                new() { Title = "Städa toa uppe", Category = ToDoCategory.Cleaning, Date = DateTime.Now },
//                new() { Title = "Walk at home", Category = ToDoCategory.Training, Date = DateTime.Now.AddDays(3) },
//            ] },
//        new UserProfile { Name = "Alve Andersson" },
//        new UserProfile { Name = "Frej Andersson" }
//    ];

//    public static WeeklyPlan GetWeeklyPlan()
//    {
//        var now = DateTime.Now;

//        var startOfWeek = now.Date.AddDays(-(now.DayOfWeek == DayOfWeek.Sunday ? 6 : now.DayOfWeek - DayOfWeek.Monday));
//        var endOfWeek = startOfWeek.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);

//        return new WeeklyPlan
//        {
//            Title = "Veckoplan",
//            StartDate = startOfWeek,
//            EndDate = endOfWeek,
//            Items =
//            [
//                new WeeklyPlanItem { Title = "Handla mat", Category = ToDoCategory.Shopping, Date = startOfWeek.AddHours(18) },
//                new WeeklyPlanItem { Title = "Städa huset", Category = ToDoCategory.Cleaning, Date = startOfWeek.AddDays(1) },
//                new WeeklyPlanItem { Title = "Träna", Category = ToDoCategory.Training, Date = startOfWeek.AddDays(2) },
//                new WeeklyPlanItem { Title = "Laga middag", Category = ToDoCategory.Cooking, Date = startOfWeek.AddDays(3) }
//            ]
//        };
//    }
//}