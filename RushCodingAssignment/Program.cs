using System;
using System.Linq;
using System.Text;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RushCodingAssignment.Business;
using RushCodingAssignment.Business.Interfaces;
using RushCodingAssignment.Data;
using RushCodingAssignment.Data.Interfaces;
using RushCodingAssignment.Service;
using RushCodingAssignment.Service.Interfaces;

namespace RushCodingAssignment
{
	public class Program
	{
		static void Main(string[] args)
		{
			var startup = new StartUp();
			var service = startup.Provider.GetRequiredService<IPhotoAlbumService>();
			if (args.Length==0)
			{
				Console.WriteLine("Invalid AlbumId. The correct usage is RushCodingAssignment.exe [AlbumId]");
				Console.WriteLine("Where AlbumId is the AlbumId number");
				return;
			}
			int albumId = 0;
			if (!int.TryParse(args[0], out albumId))
			{
				Console.WriteLine("Invalid AlbumId. AlbumId must be a number greater than zero");
				return;
			}
			if (albumId <= 0)
			{
				Console.WriteLine("Invalid AlbumId. AlbumId must be a number greater than zero");
				return;
			}
			var data = service.GetAsync(albumId).Result.ToList();
			var sb = new StringBuilder();
			foreach (var item in data)
			{
				sb.Append(item.Display());
			}
			Console.WriteLine(sb.ToString());
        }

	}
}
