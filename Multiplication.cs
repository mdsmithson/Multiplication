using System;
using System.Timers;
using System.IO;
class Program
{
	static int score {get;set;}
	static int status {get;set;}
	static int highscore {get;set;}
	static void tooslow(object source, ElapsedEventArgs e) 
	{ 
		status = 0;
		Console.WriteLine(" ");
		Console.WriteLine("Too Slow");
		highscore_check();
	}
	static void highscore_check()
	{
		if(highscore < score)
		{
			File.WriteAllText("highscore.txt",score.ToString());
			Console.WriteLine($"Congrats, you have set a new high score!");
		}
	}
	static void Main()
	{
		highscore = int.Parse(File.ReadAllText("highscore.txt"));
		Console.WriteLine($"Current Highscore of {highscore}");
		Console.WriteLine("You have 3 seconds to answer");
		status = 1;
		Random r = new Random();
		while(status==1)
		{
			System.Timers.Timer aTimer = new System.Timers.Timer();
			aTimer.Interval = 3000; 
			aTimer.Elapsed += new ElapsedEventHandler(tooslow);
			aTimer.Start();
			int a = r.Next(1,10);
			int b = r.Next(1,10);
			Console.WriteLine($"{a} * {b} ?");
			int x = int.Parse(Console.ReadLine());
			Console.WriteLine(" ");
			if(x == (a*b))
			{	
				score++;
				Console.WriteLine($"Good job, new score of {score}");
			}
			else
			{

				Console.WriteLine($"Wrong, correct answer is {a*b}");
				status = 0;
				for(int i = 1; i<=10; i++) {Console.WriteLine($"{a} * {i} = {a*i}");};
				highscore_check();
			}
			aTimer.Stop();
		}
		Console.WriteLine($"Total score of {score}");
		
	}
}
