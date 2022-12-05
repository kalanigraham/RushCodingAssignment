using RestSharp;
using RushCodingAssignment.Data.Interfaces;
using RushCodingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RushCodingAssignment.Data
{
	public class PhotoAlbumData : IPhotoAlbumData
	{
		private readonly RestClient client;
		private readonly IFileLogger _logger;
		public PhotoAlbumData(IFileLogger logger) 
		{
			_logger = logger;
			//TODO: Use configuration file to initialize url
			client = new RestClient("https://jsonplaceholder.typicode.com");
		}

		public async Task<IEnumerable<PhotoAlbumModel>> GetAsync()
		{
			try
			{
				var request = new RestRequest("/photos", Method.Get);
				return await client.GetAsync<IEnumerable<PhotoAlbumModel>>(request);
			}
			catch (Exception ex)
			{
				_logger.LogException("Exception in PhotoAlbumData", ex);
				throw;
			}

		}

		public async Task<IEnumerable<PhotoAlbumModel>> GetAsync(int id)
		{
			try
			{
				_logger.LogInfo($"Album {id} requested.");
				var request = new RestRequest("/photos", Method.Get).AddQueryParameter("albumId", id);
				return await client.GetAsync<IEnumerable<PhotoAlbumModel>>(request);
			}
			catch (Exception ex)
			{
				_logger.LogException("Exception in PhotoAlbumData", ex);
				throw;
			}
		}
	}
}
