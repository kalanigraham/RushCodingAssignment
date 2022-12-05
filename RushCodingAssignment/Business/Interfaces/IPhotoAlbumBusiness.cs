using RushCodingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RushCodingAssignment.Business.Interfaces
{
	public interface IPhotoAlbumBusiness
	{
        public Task<IEnumerable<PhotoAlbumModel>> GetAsync();
        public Task<IEnumerable<PhotoAlbumModel>> GetAsync(int id);
    }
}
