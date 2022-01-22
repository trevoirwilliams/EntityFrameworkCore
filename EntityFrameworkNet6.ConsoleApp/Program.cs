/* Simple Insert Operation Methods */
using EntityFrameworkNet5.Data;
using EntityFrameworkNet5.Domain;
using Microsoft.EntityFrameworkCore;


FootballLeageDbContext context = new FootballLeageDbContext();


//await AddNewLeague();
//await AddNewTeamsWithLeague();

/* Simple Select Queries */
////await SimpleSelectQuery();

/* Queries With Filters */
////await QueryFilters();

/* Aggregate Functions */
////await AdditionalExecutionMethods();

/*Alternative LINQ Syntax*/
////await AlternativeLinqSyntax();

///* Perform Update */
//await SimpleUpdateLeagueRecord();
//await SimpleUpdateTeamRecord();

/* Perform Delete */
////await SimpleDelete();
////await DeleteWithRelationship();

/*Tracking vs No-Tracking*/
////await TrackingVsNoTracking();

/*Adding Records with relationships*/
////Adding OneToMany Related Records
////await AddNewTeamsWithLeague();
////await AddNewTeamWithLeagueId();
////await AddNewLeagueWithTeams();

////Adding ManyToMany Records
////await AddNewMatches();

////Adding OneToOne Records
////await AddNewCoach();

/* Including Related Data - Eager Loading*/
////await QueryRelatedRecords();

/* Projections to Other Data Types or Ananymous Types */
////await SelectOneProperty();
////await AnonymousProjection();
////await StronglyTypedProjection();

/* Filter Based on Related Data */
////await FilteringWithRelatedData();

/* Querying Views */
////await QueryView();

/* Query With Raw SQL */
////await RawSQLQuery();

/* Query Stored Procedures */
////await ExecStoredProcedure();

/* RAW SQL Non-Query Commands */
////await ExecuteNonQueryCommand();



/* Select History Of Teams Table */
await TeamsQueries();
await TeamsHistoryTemporalQueries();

Console.WriteLine("Press Any Key To End....");
Console.ReadKey();

async Task TeamsQueries()
{
    var teams = await context.Teams.ToListAsync();

    foreach (var item in teams)
    {
        Console.WriteLine($"Team: {item.Name}");
    }
}

async Task TeamsHistoryTemporalQueries()
{
    var teamsHistory = await context.Teams.TemporalAll()
        .Where(x => x.Id == 61)
        .ToListAsync();

    foreach (var item in teamsHistory)
    {
        Console.WriteLine($"Id: {item.Id} | Team: {item.Name}");
    }
}



////async Task ExecuteNonQueryCommand()
////{
////    var teamId = 10;
////    var affectedRows = await context.Database.ExecuteSqlRawAsync("exec sp_DeleteTeamById {0}", teamId);

////    var teamId2 = 12;
////    var affectedRows2 = await context.Database.ExecuteSqlInterpolatedAsync($"exec sp_DeleteTeamById {teamId2}");
////}

////async Task ExecStoredProcedure()
////{
////    var teamId = 3;
////    var result = await context.Coaches.FromSqlRaw("EXEC dbo.sp_GetTeamCoach {0}", teamId).ToListAsync();
////}

////async Task RawSQLQuery()
////{
////    var name = "AS Roma";
////    var teams1 = await context.Teams.FromSqlRaw($"Select * from Teams where name = '{name}'")
////        .Include(q => q.Coach).ToListAsync();

////    var teams2 = await context.Teams.FromSqlInterpolated($"Select * from Teams where name = {name}").ToListAsync();

////}

////async  Task QueryView()
////{
////    var details = await context.TeamsCoachesLeagues.ToListAsync();
////}

////async  Task FilteringWithRelatedData()
////{
////    var leagues = await context.Leagues.Where(q => q.Teams.Any(x => x.Name.Contains("Bay"))).ToListAsync();
////}

////async  Task SelectOneProperty()
////{
////    var teams = await context.Teams.Select(q => q.Name).ToListAsync();
////}

////async  Task AnonymousProjection()
////{
////    var teams = await context.Teams.Include(q => q.Coach).Select(
////        q =>
////        new {
////            TeamName = q.Name,
////            CoachName = q.Coach.Name
////        }
////        ).ToListAsync();

////    foreach (var item in teams)
////    {
////        Console.WriteLine($"Team: {item.TeamName} | Coach: {item.CoachName}");
////    }
////}

////async  Task StronglyTypedProjection()
////{
////    var teams = await context.Teams.Include(q => q.Coach).Include(q => q.League).Select(
////        q =>
////        new TeamsCoachesLeaguesView
////        {
////            Name = q.Name,
////            CoachName = q.Coach.Name,
////            LeagueName = q.League.Name
////        }
////        ).ToListAsync();
////    foreach (var item in teams)
////    {
////        Console.WriteLine($"Team: {item.Name} | Coach: {item.CoachName} | League: {item.LeagueName}");
////    }
////}

//// async Task QueryRelatedRecords()
////{
////    //// Get Many Related Records - Leagues -> Teams
////    var leagues = await context.Leagues.Include(q => q.Teams).ToListAsync();

////    //// Get One Related Record - Team -> Coach
////    var team = await context.Teams
////        .Include(q => q.Coach)
////        .FirstOrDefaultAsync(q => q.Id == 3);

////    //// Get 'Grand Children' Related Record - Team -> Matches -> Home/Away Team
////    var teamsWithMatchesAndOpponents = await context.Teams
////        .Include(q => q.AwayMatches).ThenInclude(q => q.HomeTeam).ThenInclude(q => q.Coach)
////        .Include(q => q.HomeMatches).ThenInclude(q => q.AwayTeam).ThenInclude(q => q.Coach)
////        .FirstOrDefaultAsync(q => q.Id == 1);

////    //// Get Includes with filters
////    var teams = await context.Teams
////        .Where(q => q.HomeMatches.Count > 0)
////        .Include(q => q.Coach)
////        .ToListAsync();
////}


////async Task TrackingVsNoTracking()
////{
////    var withTracking = await context.Teams.FirstOrDefaultAsync(q => q.Id == 2);
////    var withNoTracking = await context.Teams.AsNoTracking().FirstOrDefaultAsync(q => q.Id == 8);

////    withTracking.Name = "Inter Milan";
////    withNoTracking.Name = "Rivoli United";

////    var entriesBeforeSave = context.ChangeTracker.Entries();

////    await context.SaveChangesAsync();

////    var entriesAfterSave = context.ChangeTracker.Entries();
////}

////async Task SimpleDelete()
////{
////    var league = await context.Leagues.FindAsync(4);
////    context.Leagues.Remove(league);
////    await context.SaveChangesAsync();
////}

////  async Task DeleteWithRelationship()
////{
////    var league = await context.Leagues.FindAsync(9);
////    context.Leagues.Remove(league);
////    await context.SaveChangesAsync();
////}

////  async Task SimpleUpdateTeamRecord()
////{
////    var team = new Team
////    {
////        Id = 7,
////        Name = "Seba United FC",
////        LeagueId = 2
////    };
////    context.Teams.Update(team);
////    await context.SaveChangesAsync("Test Update User");
////}

////async Task GetRecord()
////{
////    ////Retrieve Record
////    var league = await context.Leagues.FindAsync(3);
////    Console.WriteLine($"{league.Id} - {league.Name}");
////}

////  async Task SimpleUpdateLeagueRecord()
////{
////    ////Retrieve Record
////    var league = await context.Leagues.FindAsync(20);
////    ///Make Record Changes
////    league.Name = "Scottish Premiership";
////    ///Save Changes
////    await context.SaveChangesAsync();

////    await GetRecord();

////}

//// async Task AlternativeLinqSyntax()
////{
////    Console.Write($"Enter Team Name (Or Part Of): ");
////    var teamName = Console.ReadLine();
////    var teams = await (from i in context.Teams
////                       where EF.Functions.Like(i.Name, $"%{teamName}%")
////                       select i).ToListAsync();

////    foreach (var team in teams)
////    {
////        Console.WriteLine($"{team.Id} - {team.Name}");
////    }
////}

//// async Task AdditionalExecutionMethods()
////{
////    //// These methods also have non-async
////    var leagues = context.Leagues;
////    var list = await leagues.ToListAsync();
////    var first = await leagues.FirstAsync();
////    var firstOrDefault = await leagues.FirstOrDefaultAsync();
////    var single = await leagues.SingleAsync();
////    var singleOrDefault = await leagues.SingleOrDefaultAsync();

////    var count = await leagues.CountAsync();
////    var longCount = await leagues.LongCountAsync();
////    var min = await leagues.MinAsync();
////    var max = await leagues.MaxAsync();

////    //// DbSet Method that will execute
////    var league = await leagues.FindAsync(1);

////}

//// async Task QueryFilters()
////{
////    Console.Write($"Enter League Name (Or Part Of): ");
////    var leagueName = Console.ReadLine();
////    var exactMatches = await context.Leagues.Where(q => q.Name.Equals(leagueName)).ToListAsync();
////    foreach (var league in exactMatches)
////    {
////        Console.WriteLine($"{league.Id} - {league.Name}");
////    }

////    ////var partialMatches = await context.Leagues.Where(q => q.Name.Contains(leagueName)).ToListAsync();
////    var partialMatches = await context.Leagues.Where(q => EF.Functions.Like(q.Name, $"%{leagueName}%")).ToListAsync();
////    foreach (var league in partialMatches)
////    {
////        Console.WriteLine($"{league.Id} - {league.Name}");
////    }
////}

//// async Task SimpleSelectQuery()
////{
////    //// Smartest most efficient way to get results
////    var leagues = await context.Leagues.ToListAsync();
////    foreach (var league in leagues)
////    {
////        Console.WriteLine($"{league.Id} - {league.Name}");
////    }

////    //// Inefficient way to get results. Keeps connection open until completed and might create lock on table
////    ////foreach (var league in context.Leagues)
////    ////{
////    ////    Console.WriteLine($"{league.Id} - {league.Name}");
////    ////}

////}

//// async Task AddNewLeague()
////{
////    //// Adding a new League Object
////    var league = new League { Name = "Audit Testing League 1" };
////    await context.Leagues.AddAsync(league);
////    await context.SaveChangesAsync("Test Audit Create User");

////    //// Function To add new teams related to the new league object. 
////    await AddTeamsWithLeague(league);
////    await context.SaveChangesAsync();
////}

//// async Task AddTeamsWithLeague(League league)
////{
////    var teams = new List<Team>
////            {
////                new Team
////                {
////                    Name = "Juventus",
////                    LeagueId = league.Id
////                },
////                new Team
////                {
////                    Name = "AC Milan",
////                    LeagueId = league.Id
////                },
////                new Team
////                {
////                    Name = "AS Roma",
////                    League = league
////                }
////            };

////    //// Operation to add multiple objects to database in one call.
////    await context.AddRangeAsync(teams);
////}

//// async Task AddNewTeamsWithLeague()
////{
////    var league = new League { Name = "Bundesliga" };
////    var team = new Team { Name = "Bayern Munich", League = league };
////    await context.AddAsync(team);
////    await context.SaveChangesAsync();
////}

// async Task AddNewTeamWithLeagueId()
//{
//    var team = new Team { Name = "Fiorentina", LeagueId = 8 };
//    await context.AddAsync(team);
//    await context.SaveChangesAsync();
//}

// async Task AddNewLeagueWithTeams()
//{
//    var teams = new List<Team> {
//                new Team
//                {
//                    Name = "Rivoli United"
//                },
//                new Team
//                {
//                    Name = "Waterhouse FC"
//                },
//            };
//    var league = new League { Name = "CIFA", Teams = teams };
//    await context.AddAsync(league);
//    await context.SaveChangesAsync();
//}

//// async Task AddNewMatches()
////{
////    var matches = new List<Match>
////            {
////                new Match
////                {
////                    AwayTeamId = 1, HomeTeamId = 2, Date = new DateTime(2021, 10, 28)
////                },
////                new Match
////                {
////                    AwayTeamId = 8, HomeTeamId = 7, Date = DateTime.Now
////                },
////                new Match
////                {
////                    AwayTeamId = 8, HomeTeamId = 7, Date = DateTime.Now
////                }
////            };
////    await context.AddRangeAsync(matches);
////    await context.SaveChangesAsync();
////}

////  async Task AddNewCoach()
////{
////    var coach1 = new Coach { Name = "Jose Mourinho", TeamId = 3 };

////    await context.AddAsync(coach1);

////    var coach2 = new Coach { Name = "Antonio Conte" };

////    await context.AddAsync(coach2);
////    await context.SaveChangesAsync();
////}
