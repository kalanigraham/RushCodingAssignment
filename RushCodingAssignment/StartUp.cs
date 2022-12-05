using Microsoft.Extensions.DependencyInjection;
using RushCodingAssignment.Business;
using RushCodingAssignment.Business.Interfaces;
using RushCodingAssignment.Data;
using RushCodingAssignment.Data.Interfaces;
using RushCodingAssignment.Service;
using RushCodingAssignment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RushCodingAssignment
{
	public class StartUp
	{
		private IServiceProvider provider;

		public StartUp() 
		{
			var services = new ServiceCollection();
			services.AddSingleton<IFileLogger, FileLogger>();
            services.AddSingleton<IPhotoAlbumService, PhotoAlbumService>();
            services.AddSingleton<IPhotoAlbumBusiness, PhotoAlbumBusiness>();
			services.AddSingleton<IPhotoAlbumData, PhotoAlbumData>();

			provider = services.BuildServiceProvider();
        }

        public IServiceProvider Provider => provider;
	}
}
