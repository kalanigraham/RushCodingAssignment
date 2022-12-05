using Microsoft.Extensions.Logging;
using RushCodingAssignment.Business.Interfaces;
using RushCodingAssignment.Models;
using RushCodingAssignment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RushCodingAssignment.Service
{
	public class PhotoAlbumService : IPhotoAlbumService
	{
		private readonly IPhotoAlbumBusiness _business;
		private readonly IFileLogger _logger;
		public PhotoAlbumService(IPhotoAlbumBusiness business, IFileLogger logger) 
		{
			_business = business;
			_logger = logger;
			_logger.LogInfo("Service Started");
		}

		public async Task<IEnumerable<PhotoAlbumModel>> GetAsync()
		{
			return await _business.GetAsync();
		}

		public async Task<IEnumerable<PhotoAlbumModel>> GetAsync(int id)
		{
			return await _business.GetAsync(id);
		}
	}
}
