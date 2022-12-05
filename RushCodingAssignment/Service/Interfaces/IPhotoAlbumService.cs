using RushCodingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RushCodingAssignment.Service.Interfaces
{
	public interface IPhotoAlbumService
	{
		public Task<IEnumerable<PhotoAlbumModel>> GetAsync();
		public Task<IEnumerable<PhotoAlbumModel>> GetAsync(int id);
	}
}
