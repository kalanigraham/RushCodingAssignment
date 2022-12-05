using System;
using System.Collections.Generic;
using System.Text;

namespace RushCodingAssignment.Models
{
	public class PhotoAlbumModel
	{
		public int AlbumId { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string ThumbnailUrl { get; set; }

		public string Display()
		{
			return $"[{Id}] - {Title} ";
		}
	}
}
