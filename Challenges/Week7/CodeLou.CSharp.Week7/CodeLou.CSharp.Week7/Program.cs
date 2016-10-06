using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLou.CSharp.Week7
{
    class Program
    {
        static void Main(string[] args)
        {

            // When done with a task, change it to completed:true to get it out of the way. 
            Task("Go Take a look at the context, and look at the initializer, and guess what it does. ", completed: false);
            
            // Best practise: use a context for a small job, and then get rid of it. 
            using (var context = new AstronomyContext())
            {
                // this next line outputs all SQL operations to console.
                context.Database.Log = Console.Write;

                var allPlanets = context.Planets.ToList(); 
                Question("At this point, how many planets in the db?", yourAnswer: null);

                // Insert a planet
                context.Planets.Add(new Planet() { Name = "Mercury" });

                Question("Is the planet saved to the database yet?", yourAnswer: null);

                context.SaveChanges();

                Question("Could you find the SQL generated to save the planet?", yourAnswer: null);

                context.Planets.Add(new Planet() { Name = "Venus" });
                context.Planets.Add(new Planet() { Name = "Earth" });
                context.Planets.Add(new Planet() { Name = "Mars" });
                context.Planets.Add(new Planet() { Name = "Jupiter" });
                context.Planets.Add(new Planet() { Name = "Saturn" });
                context.Planets.Add(new Planet() { Name = "Uranus" });
                context.Planets.Add(new Planet() { Name = "Nerptune" }); // the spelling is intentional, see below. 
                context.Planets.Add(new Planet() { Name = "Pluto" });
                context.SaveChanges();

                allPlanets = context.Planets.ToList(); 
                Question("How many planets in the database now?", yourAnswer: null);
            }

            // Lets do some queries. 
            using (var context = new AstronomyContext())
            {
                context.Database.Log = Console.Write;

                var planetsInAlphabeticalOrder = context.Planets.OrderBy(x => x.Name);
                Question("Does the planetsInAlphabeticalOrder query happen above, or below, this line?", yourAnswer: null);
                Console.WriteLine(String.Join(", ", planetsInAlphabeticalOrder.Select(x => x.Name)));
                

                var planetsWithLetterECount = context.Planets.Where(x => x.Name.Contains("e")).Count();
                Question("Does the planetsWithLetterE query happen above or below, this line?", yourAnswer:null);
                Console.WriteLine("Number of planets with letter e: {0}", planetsWithLetterECount);
            }

            // we have an error! Nerptune needs to be renamed! lets go fix it!
            foreach (var i in Enumerable.Range(1, 2))
            {
                using (var context = new AstronomyContext())
                {
                    context.Database.Log = Console.Write;
                    var nerptune = context.Planets.FirstOrDefault(x => x.Name == "Nerptune");

                    if (nerptune != null)
                    {
                        nerptune.Name = "Neptune";
                        context.SaveChanges();
                    }else
                    {
                        Console.WriteLine("Not Found");
                    }
                }
                Question("Coudl you find the SQL that found the planet?", yourAnswer: null);
                Question("Could you find the SQL that updated the planet?", yourAnswer: null);
            }

            // We also have to get rid of pluto. 
            using (var context = new AstronomyContext())
            {
                context.Database.Log = Console.Write;
                var pluto = context.Planets.Where(x => x.Name == "Pluto").FirstOrDefault();
                Question("How is the search for pluto different from the search for Nerptune?", yourAnswer: null); 
                context.Planets.Remove(pluto);
                context.SaveChanges();
                Question("Could you find the SQL generated to delete pluto?", yourAnswer: null);
            }

            // Change Tasks to completed = true when you're done with them. 
            Task("Add a class for Moon. it should have a MoonID and a MoonName", completed: false);
            Task("Now, Add a DbSet for Moons. ", completed: false);
            Task("Add in our moon, Moon, and Mars' two moons from below:");
            // https://www.windows2universe.org/our_solar_system/moons_table.html
            Task("Add in a moon: Death Star");
            Task("Dump out all the moons so far to console -- should be 4. ");
            Task("using a context, find the Death Star and delete it");
            Task("using a context, Rename our one moon to Luna");
            Task("Dump out all the moons again.  Don't DRY, reuse.");

            Console.WriteLine("You have answered {0}/{1} Questions", numAnswers, numQuestions);
            Console.WriteLine("You have completed {0}/{1} Tasks", numCompletedTasks, numTasks);

            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
        }

        public static int numQuestions = 0; 
        public static int numAnswers = 0; 
        public static void Question(string question, string yourAnswer = null)
        {
            numQuestions++; 
            if (string.IsNullOrEmpty(yourAnswer))
            {
                Console.WriteLine(); 
                Console.WriteLine("UNANSWERED QUESTION=================");
                Console.WriteLine(question);
                Console.WriteLine("====================================");
                Console.WriteLine(); 
            }
            else
            {
                numAnswers++;
                Console.WriteLine(); 
                Console.WriteLine("Question: {0}", question);
                Console.WriteLine("Your Answer: {0}", yourAnswer);
                Console.WriteLine();
            }
        }

        public static int numTasks = 0;
        public static int numCompletedTasks = 0; 
        public static void Task(string task, bool completed = false)
        {
            numTasks++;
            if (!completed)
            {
                Console.WriteLine();
                Console.WriteLine("TASK================================");
                Console.WriteLine(task);
                Console.WriteLine("====================================");
                Console.WriteLine();
            }
            else
            {
                numCompletedTasks++;
                Console.WriteLine();
                Console.WriteLine("TASK: {0} (COMPLETED)", task);
                Console.WriteLine();
            }
        }
    }

    public class AstronomyContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }

        public AstronomyContext()
        {
            // This means you always start out with a blank database. 
            Database.SetInitializer<AstronomyContext>(new DropCreateDatabaseAlways<AstronomyContext>());
        }
    }

    public class Planet
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
    }
}
