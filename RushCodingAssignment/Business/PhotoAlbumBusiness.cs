using RushCodingAssignment.Business.Interfaces;
using RushCodingAssignment.Data.Interfaces;
using RushCodingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RushCodingAssignment.Business
{
	public class PhotoAlbumBusiness : IPhotoAlbumBusiness
	{
        private readonly IPhotoAlbumData _data;
		private readonly IFileLogger _logger;

		public PhotoAlbumBusiness(IPhotoAlbumData data, IFileLogger logger)
		{
			_data = data;
			_logger = logger;
		}

		public async Task<IEnumerable<PhotoAlbumModel>> GetAsync()
		{
			return await _data.GetAsync();
		}

		public async Task<IEnumerable<PhotoAlbumModel>> GetAsync(int id)
		{
			if (id <= 0)
			{
				_logger.LogError($"AlbumId of {id} attempted");
				throw new ArgumentException("AlbumId must be a greater than 0");
			}
			return await _data.GetAsync(id);
		}
	}
}
