using hometask5.Models;

public static class DbSeeder
{
    public static void Seed(ApplicationContext context)
    {
        if (!context.Groups.Any())
        {
            var g1 = new Group { GrName = "Гематологія", GrTemp = 4.0f };
            var g2 = new Group { GrName = "Біохімія", GrTemp = 5.0f };
            var g3 = new Group { GrName = "Імунологія", GrTemp = 20.0f };
            var g4 = new Group { GrName = "Гормони", GrTemp = 6.0f };

            context.Groups.AddRange(g1, g2, g3, g4);
            context.SaveChanges();

            var a1 = new Analysis { AnName = "Загальний аналіз крові", AnCost = 50.00m, AnPrice = 150.00m, AnGroup = g1.GrId };
            var a2 = new Analysis { AnName = "Глюкоза", AnCost = 30.00m, AnPrice = 100.00m, AnGroup = g2.GrId };
            var a3 = new Analysis { AnName = "АЛТ", AnCost = 40.00m, AnPrice = 120.00m, AnGroup = g2.GrId };
            var a4 = new Analysis { AnName = "IgG до кору", AnCost = 70.00m, AnPrice = 200.00m, AnGroup = g3.GrId };
            var a5 = new Analysis { AnName = "TSH (тиреотропний гормон)", AnCost = 60.00m, AnPrice = 220.00m, AnGroup = g4.GrId };

            context.Analyses.AddRange(a1, a2, a3, a4, a5);
            context.SaveChanges();

            var orders = new[]
            {
                new Order { OrdDatetime = DateTime.Parse("2020-02-05 08:30:00"), OrdAn = a1.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-02-05 09:15:00"), OrdAn = a2.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-02-06 10:45:00"), OrdAn = a1.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-02-08 11:30:00"), OrdAn = a3.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-02-10 15:00:00"), OrdAn = a4.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-02-11 12:10:00"), OrdAn = a5.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-01-15 08:00:00"), OrdAn = a1.AnId },
                new Order { OrdDatetime = DateTime.Parse("2020-03-20 09:45:00"), OrdAn = a2.AnId },
                new Order { OrdDatetime = DateTime.Parse("2021-01-10 10:10:00"), OrdAn = a1.AnId },
                new Order { OrdDatetime = DateTime.Parse("2021-02-14 14:00:00"), OrdAn = a3.AnId },
                new Order { OrdDatetime = DateTime.Parse("2021-02-20 11:00:00"), OrdAn = a3.AnId },
                new Order { OrdDatetime = DateTime.Parse("2021-04-01 13:30:00"), OrdAn = a5.AnId },
                new Order { OrdDatetime = DateTime.Parse("2022-01-05 10:00:00"), OrdAn = a2.AnId },
                new Order { OrdDatetime = DateTime.Parse("2022-01-25 09:20:00"), OrdAn = a4.AnId },
                new Order { OrdDatetime = DateTime.Parse("2022-03-10 15:45:00"), OrdAn = a5.AnId },
                new Order { OrdDatetime = DateTime.Parse("2022-04-22 10:50:00"), OrdAn = a5.AnId },
                new Order { OrdDatetime = DateTime.Parse("2022-05-18 08:00:00"), OrdAn = a4.AnId },
                new Order { OrdDatetime = DateTime.Parse("2023-02-01 09:00:00"), OrdAn = a1.AnId },
                new Order { OrdDatetime = DateTime.Parse("2025-03-15 12:00:00"), OrdAn = a2.AnId },
                new Order { OrdDatetime = DateTime.Parse("2025-05-18 08:00:00"), OrdAn = a4.AnId },
                new Order { OrdDatetime = DateTime.Parse("2025-02-01 09:00:00"), OrdAn = a1.AnId },
                new Order { OrdDatetime = DateTime.Parse("2025-03-15 12:00:00"), OrdAn = a2.AnId },
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
